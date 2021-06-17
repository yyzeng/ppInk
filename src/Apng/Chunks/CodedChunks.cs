using System;
using System.IO;
using gInk.Extensions;
using gInk.Apng.Chunks;

namespace gInk.Apng.Chunks
{

    // ////////////////// from acTLChunks.cs

    public class AcTlChunk : Chunk
    {
        public AcTlChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public AcTlChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public AcTlChunk(Chunk chunk)
            : base(chunk)
        {
        }

        public uint NumFrames { get; private set; }

        public uint NumPlays { get; private set; }

        protected override void ParseData(MemoryStream ms)
        {
            NumFrames = Helper.ConvertEndian(ms.ReadUInt32());
            NumPlays = Helper.ConvertEndian(ms.ReadUInt32());
        }
    }

    // ////////////////// from fcTLChunks.cs

    public enum DisposeOps
    {
        ApngDisposeOpNone = 0,
        ApngDisposeOpBackground = 1,
        ApngDisposeOpPrevious = 2,
    }

    public enum BlendOps
    {
        ApngBlendOpSource = 0,
        ApngBlendOpOver = 1,
    }

    public class FcTlChunk : Chunk
    {
        public FcTlChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public FcTlChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public FcTlChunk(Chunk chunk)
            : base(chunk)
        {
        }

        /// <summary>
        ///     Sequence number of the animation chunk, starting from 0
        /// </summary>
        public uint SequenceNumber { get; private set; }

        /// <summary>
        ///     Width of the following frame
        /// </summary>
        public uint Width { get; private set; }

        /// <summary>
        ///     Height of the following frame
        /// </summary>
        public uint Height { get; private set; }

        /// <summary>
        ///     X position at which to render the following frame
        /// </summary>
        public uint XOffset { get; private set; }

        /// <summary>
        ///     Y position at which to render the following frame
        /// </summary>
        public uint YOffset { get; private set; }

        /// <summary>
        ///     Frame delay fraction numerator
        /// </summary>
        public ushort DelayNum { get; private set; }

        /// <summary>
        ///     Frame delay fraction denominator
        /// </summary>
        public ushort DelayDen { get; private set; }

        /// <summary>
        ///     Type of frame area disposal to be done after rendering this frame
        /// </summary>
        public DisposeOps DisposeOp { get; private set; }

        /// <summary>
        ///     Type of frame area rendering for this frame
        /// </summary>
        public BlendOps BlendOp { get; private set; }

        protected override void ParseData(MemoryStream ms)
        {
            SequenceNumber = Helper.ConvertEndian(ms.ReadUInt32());
            Width = Helper.ConvertEndian(ms.ReadUInt32());
            Height = Helper.ConvertEndian(ms.ReadUInt32());
            XOffset = Helper.ConvertEndian(ms.ReadUInt32());
            YOffset = Helper.ConvertEndian(ms.ReadUInt32());
            DelayNum = Helper.ConvertEndian(ms.ReadUInt16());
            DelayDen = Helper.ConvertEndian(ms.ReadUInt16());
            DisposeOp = (DisposeOps)ms.ReadByte();
            BlendOp = (BlendOps)ms.ReadByte();
        }
    }

    // from FdAtChunk.cs
    public class FdAtChunk : Chunk
    {
        public FdAtChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public FdAtChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public FdAtChunk(Chunk chunk)
            : base(chunk)
        {
        }

        public uint SequenceNumber { get; private set; }

        public byte[] FrameData { get; private set; }

        protected override void ParseData(MemoryStream ms)
        {
            SequenceNumber = Helper.ConvertEndian(ms.ReadUInt32());
            FrameData = ms.ReadBytes((int)Length - 4);
        }

        public IdatChunk ToIdatChunk()
        {
            uint newCrc;
            using (var msCrc = new MemoryStream())
            {
                msCrc.WriteBytes(new[] { (byte)'I', (byte)'D', (byte)'A', (byte)'T' });
                msCrc.WriteBytes(FrameData);

                newCrc = CrcHelper.Calculate(msCrc.ToArray());
            }

            using (var ms = new MemoryStream())
            {
                ms.WriteUInt32(Helper.ConvertEndian(Length - 4));
                ms.WriteBytes(new[] { (byte)'I', (byte)'D', (byte)'A', (byte)'T' });
                ms.WriteBytes(FrameData);
                ms.WriteUInt32(Helper.ConvertEndian(newCrc));
                ms.Position = 0;

                return new IdatChunk(ms);
            }
        }
    }

    // ////////////////////// from IDAtChunk.cs
    public class IdatChunk : Chunk
    {
        public IdatChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public IdatChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public IdatChunk(Chunk chunk)
            : base(chunk)
        {
        }
    }

    // ///////////////////// from IENDChunk.cs

    public class IendChunk : Chunk
    {
        public IendChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public IendChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public IendChunk(Chunk chunk)
            : base(chunk)
        {
        }
    }


    // //////////////////////// from IHDRChunk.cs
    public class IhdrChunk : Chunk
    {
        public IhdrChunk(byte[] chunkBytes)
            : base(chunkBytes)
        {
        }

        public IhdrChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public IhdrChunk(Chunk chunk)
            : base(chunk)
        {
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public byte BitDepth { get; private set; }

        public byte ColorType { get; private set; }

        public byte CompressionMethod { get; private set; }

        public byte FilterMethod { get; private set; }

        public byte InterlaceMethod { get; private set; }

        protected override void ParseData(MemoryStream ms)
        {
            Width = Helper.ConvertEndian(ms.ReadInt32());
            Height = Helper.ConvertEndian(ms.ReadInt32());
            BitDepth = Convert.ToByte(ms.ReadByte());
            ColorType = Convert.ToByte(ms.ReadByte());
            CompressionMethod = Convert.ToByte(ms.ReadByte());
            FilterMethod = Convert.ToByte(ms.ReadByte());
            InterlaceMethod = Convert.ToByte(ms.ReadByte());
        }
    }

    // ////////////////////////// from OtherChunk.cs

    public class OtherChunk : Chunk
    {
        public OtherChunk(byte[] bytes)
            : base(bytes)
        {
        }

        public OtherChunk(MemoryStream ms)
            : base(ms)
        {
        }

        public OtherChunk(Chunk chunk)
            : base(chunk)
        {
        }

        protected override void ParseData(MemoryStream ms)
        {
        }
    }

}
