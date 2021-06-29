using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using gInk.Extensions;
using gInk.Apng.Chunks;
using System.Drawing;

namespace gInk.Apng
{
    public class Frame
    {
        public static readonly byte[] Signature = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

        private List<IdatChunk> _idatChunks = new List<IdatChunk>();
        private List<OtherChunk> _otherChunks = new List<OtherChunk>();

        /// <summary>
        ///     Gets or Sets the acTL chunk
        /// </summary>
        public IhdrChunk IhdrChunk { get; set; }

        /// <summary>
        ///     Gets or Sets the fcTL chunk
        /// </summary>
        public FcTlChunk FcTlChunk { get; set; }

        /// <summary>
        ///     Gets or Sets the IEND chunk
        /// </summary>
        public IendChunk IendChunk { get; set; }

        ~Frame()
        {
            if (_image != null)
                _image.Dispose();
        }

        /// <summary>
        ///     Gets or Sets the other chunks
        /// </summary>
        public List<OtherChunk> OtherChunks
        {
            get => _otherChunks;
            set => _otherChunks = value;
        }

        /// <summary>
        ///     Gets or Sets the IDAT chunks
        /// </summary>
        public List<IdatChunk> IdatChunks
        {
            get => _idatChunks;
            set => _idatChunks = value;
        }

        /// <summary>
        ///     Add an Chunk to end end of existing list.
        /// </summary>
        public void AddOtherChunk(OtherChunk chunk)
        {
            _otherChunks.Add(chunk);
        }

        /// <summary>
        ///     Add an IDAT Chunk to end end of existing list.
        /// </summary>
        public void AddIdatChunk(IdatChunk chunk)
        {
            _idatChunks.Add(chunk);
        }

        /// <summary>
        ///     Gets the frame as PNG FileStream.
        /// </summary>
        public MemoryStream GetStream()
        {
            var ihdrChunk = new IhdrChunk(IhdrChunk);
            if (FcTlChunk != null)
            {
                // Fix frame size with fcTL data.
                ihdrChunk.ModifyChunkData(0, Helper.ConvertEndian(FcTlChunk.Width));
                ihdrChunk.ModifyChunkData(4, Helper.ConvertEndian(FcTlChunk.Height));
            }

            // Write image data
            var ms = new MemoryStream();

            ms.WriteBytes(Signature);
            ms.WriteBytes(ihdrChunk.RawData);
            _otherChunks.ForEach(o => ms.WriteBytes(o.RawData));
            _idatChunks.ForEach(i => ms.WriteBytes(i.RawData));
            ms.WriteBytes(IendChunk.RawData);

            ms.Position = 0;
            return ms;

        }

        public Image _image;
        
        public double _delay=-1;

        public Image GetImage()
        {
            if(_image==null)
            {
                _image = Image.FromStream(GetStream());
            }
            return _image;
        }

        public double GetDelay()
        {
            if(_delay<0)
            {
                _delay = (1.0 * FcTlChunk.DelayNum) / (FcTlChunk.DelayDen==0? 100:FcTlChunk.DelayDen);
            }
            return _delay;
        }

    }
}
