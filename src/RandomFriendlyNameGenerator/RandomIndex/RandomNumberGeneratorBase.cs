using System;
using System.Security.Cryptography;

namespace RandomFriendlyNameGenerator
{
    //https://stackoverflow.com/a/11258708/2892378
    public abstract class RandomNumberGeneratorBase
    {
        private int _byteBufSize;
        private byte[] _buf;
        private int _idx;
        private int _lastsize;

        public RandomNumberGeneratorBase(int bufSize = 8092* 8092)
        {
            this._byteBufSize = bufSize;
            this._buf = new byte[this._byteBufSize];
            this._idx = this._byteBufSize;
        }

        protected abstract void GetNewBuf(byte[] buf);

        private void CheckBuf(int bytesFreeNeeded = 1)
        {
            this._idx += this._lastsize;
            this._lastsize = bytesFreeNeeded;
            if (this._idx + bytesFreeNeeded < this._byteBufSize) { return; }
            this.GetNewBuf(this._buf);
            this._idx = 0;
            this._lastsize = 0;
        }

        public int GetRandomIntStartAtZero(int belowValue)
        {
            return (int)(Math.Round(((double)this.GetRandomUInt32() * (double)(belowValue - 1)) / (double)uint.MaxValue));
        }

        public bool GetRandomBool()
        {
            this.CheckBuf();
            return this._buf[this._idx] > 127;
        }

        public uint GetRandomUInt32()
        {
            this.CheckBuf(sizeof(UInt32));
            return BitConverter.ToUInt32(this._buf, this._idx);
        }
    }

    public sealed class StrongRandomNumberGenerator : RandomNumberGeneratorBase
    {
        private RNGCryptoServiceProvider _rnd;

        public StrongRandomNumberGenerator()
        {
            _rnd = new RNGCryptoServiceProvider();
        }

        protected override void GetNewBuf(byte[] buf)
        {
            _rnd.GetBytes(buf);
        }

    }
}