using System;
using System.Collections;
using System.Collections.Generic;

namespace Primes
{
    public class SoE
    {
        //http://stackoverflow.com/questions/1569393/c-how-to-make-sieve-of-atkin-incremental/18139477#18139477
        public static IEnumerable<ulong> Primes(ulong topNumber)
        {
            if (topNumber < 2u)
                yield break;
            yield return 2u;
            if (topNumber < 3u)
                yield break;
            var bitArrayLimit = (topNumber - 3u)/2u;
            var sqrtLimit = ((ulong) Math.Sqrt(topNumber) - 3u)/2u;
            var buf = new BitArray((int) bitArrayLimit + 1, true);
            for (var i = 0u; i <= bitArrayLimit; ++i)
                if (buf[(int) i])
                {
                    var p = 3u + i + i;
                    if (i <= sqrtLimit)
                        for (var j = (p*p - 3u)/2u; j <= bitArrayLimit; j += p)
                            buf[(int) j] = false;
                    yield return p;
                }
        }

        public static IEnumerable<ulong> PrimesWheel(ulong topNumber)
        {
            if (topNumber < 2u) 
                yield break;
            yield return 2u;
            if (topNumber < 3u) 
                yield break;
            yield return 3u;
            if (topNumber < 5u) 
                yield break;
            yield return 5u;
            if (topNumber < 7u) 
                yield break;
            var bitArrayLimit = (topNumber - 7u)/2u;
            var sqrtLimit = ((ulong) Math.Sqrt(topNumber) - 7u)/2u;
            var buf = new BitArray((int) bitArrayLimit + 1, true);
            byte[] wheelFactorisation = {2, 1, 2, 1, 2, 3, 1, 3};
            for (ulong i = 0u, w = 0u; i <= bitArrayLimit; i += wheelFactorisation[w], w = (w < 7u) ? ++w : 0u)
                if (buf[(int) i])
                {
                    var p = 7u + i + i;
                    if (i <= sqrtLimit)
                    {
                        var pX2 = p + p;
                        ulong[] pa = {p, pX2, pX2 + p};
                        for (ulong j = (p*p - 7u)/2u, m = w; j <= bitArrayLimit;
                             j += pa[wheelFactorisation[m] - 1u], m = (m < 7u) ? ++m : 0u)
                            buf[(int) j] = false;
                    }
                    yield return p;
                }
        }

        public static IEnumerable<ulong> PrimesCacheFriendly(ulong topNumber)
        {
            yield return 2u;
            yield return 3u;
            yield return 5u;
            const ulong l1CachePower = 14u + 3u, l1CacheSize = (1u << (int) l1CachePower); //for 16K in bits...
            const ulong bufferSize = l1CacheSize/15u*15u; //an even number of wheel rotations
            var buf = new BitArray((int) bufferSize);
            ulong maxNumberRange = (topNumber - 7u)/2u; //need maximum for number range
            //var sqrtLimit = ((ulong) Math.Sqrt(ulong.MaxValue) - 7u)/2u;
            byte[] wheelFactorisation = {2, 1, 2, 1, 2, 3, 1, 3}; //the 2,3,5 factorial wheel, (sum) 15 elements long
            byte[] wheelPosition = {0, 2, 3, 5, 6, 8, 11, 12}; //get wheel position from index
            byte[] wheelIndex =
                {
                    0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 5, 6, 7, 7, 7, //get index from position
                    0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 5, 6, 7
                }; //allow for overflow
            byte[] wheelRoundUp =
                {
                    0, 2, 2, 3, 5, 5, 6, 8, 8, 11, 11, 11, 12, 15, //allow for overflow...
                    15, 15, 17, 17, 18, 20, 20, 21, 23, 23, 26, 26, 26, 27
                };
            const uint bitArrayLimit = (ushort.MaxValue - 7u) / 2u;
            var bpbuf = new BitArray((int) bitArrayLimit + 1, true);
            for (int i = 0; i <= 124; ++i)
                if (bpbuf[i])
                {
                    var p = 7 + i + i; //initialize baseprimes array
                    for (int j = (p * p - 7) / 2; j <= bitArrayLimit; j += p) 
                        bpbuf[j] = false;
                }
            var pa = new ulong[3];
            for (ulong i = 0u, w = 0, si = 0; i <= maxNumberRange;
                 i += wheelFactorisation[w], si += wheelFactorisation[w], si = (si >= bufferSize) ? 0u : si, w = (w < 7u) ? ++w : 0u)
            {
                if (si == 0)
                {
                    buf.SetAll(true);
                    for (ulong j = 0u, bw = 0u; j <= bitArrayLimit; j += wheelFactorisation[bw], bw = (bw < 7u) ? ++bw : 0u)
                        if (bpbuf[(int) j])
                        {
                            var p = 7u + j + j;
                            var pX2 = p + p;
                            var k = p*(j + 3u) + j;
                            if (k >= i + bufferSize) break;
                            pa[0] = p;
                            pa[1] = pX2;
                            pa[2] = pX2 + p;
                            var sw = bw;
                            if (k < i)
                            {
                                k = (i - k)%(15u*p);
                                if (k != 0)
                                {
                                    var os = wheelPosition[bw];
                                    sw = os + ((k + p - 1u)/p);
                                    sw = wheelRoundUp[sw];
                                    k = (sw - os)*p - k;
                                    sw = wheelIndex[sw];
                                }
                            }
                            else 
                                k -= i;
                            for (; k < bufferSize; k += pa[wheelFactorisation[sw] - 1], sw = (sw < 7u) ? ++sw : 0u) 
                                buf[(int) k] = false;
                        }
                }
                if (buf[(int) si]) 
                    yield return 7u + i + i;
            }
        }
    }

    //internal class fastprimesSoE : IEnumerable<ulong>, IEnumerable
    //{
    //    private struct procspc
    //    {
    //        public Task tsk;
    //        public ulong[] buf;
    //    }

    //    private struct wst
    //    {
    //        public byte msk;
    //        public byte mlt;
    //        public byte xtr;
    //        public byte nxt;
    //    }

    //    private static readonly ulong NUMPROCS = (ulong) Environment.ProcessorCount + 1u;
    //    private const ulong CHNKSZ = 1u;
    //    private const ulong L1CACHEPOW = 18u, L1CACHESZ = (1u << (int) L1CACHEPOW), PGSZ = L1CACHESZ >> 2; //for 16K in bytes...
    //    private const ulong BUFSZ = CHNKSZ*PGSZ; //number of ulongs even number of caches in chunk
    //    private const ulong BUFSZBTS = 15u*BUFSZ << 2; //even in wheel rotations and ulongs (and chunks)
    //    private static readonly byte[] WHLPTRN = {2, 1, 2, 1, 2, 3, 1, 3}; //the 2,3,5 factorial wheel, (sum) 15 elements long
    //    private static readonly byte[] WHLPOS = {0, 2, 3, 5, 6, 8, 11, 12}; //get wheel position from index
    //    private static readonly byte[] WHLNDX =
    //        {
    //            0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 5, 6, 7, 7, 7, //get index from position
    //            0, 0, 1, 2, 2, 3, 4, 4, 5, 5, 5, 6, 7
    //        }; //allow for overflow
    //    private static readonly byte[] WHLRNDUP =
    //        {
    //            0, 2, 2, 3, 5, 5, 6, 8, 8, 11, 11, 11, 12, 15, //allow for overflow...
    //            15, 15, 17, 17, 18, 20, 20, 21, 23, 23, 26, 26, 26, 27
    //        }; //round multiplier up
    //    private const ulong BPLMT = (ushort.MaxValue - 7u)/2u;
    //    private const ulong BPSZ = BPLMT/60u + 1u;
    //    private static readonly ulong[] bpbuf = new ulong[BPSZ];
    //    private static readonly wst[] WHLST = new wst[64];
    //    private static void cullpg(ulong i, ulong[] b, int strt, int cnt)
    //    {
    //        Array.Clear(b, strt, cnt);
    //        for (ulong j = 0u, bw = 0x31321212u, bi = 0u, v = 0xc0881000u, bm = 1u; j <= BPLMT;
    //             j += bw & 0xF, bw = (bw > 3u) ? bw >>= 4 : 0x31321212u)
    //        {
    //            if ((v & bm) == 0u)
    //            {
    //                var p = 7u + j + j;
    //                var k = p*(j + 3u) + j;
    //                if (k >= i + cnt*60) break;
    //                var pp = j%15u;
    //                if (k < i)
    //                {
    //                    k = (i - k)%(15u*p);
    //                    if (k != 0)
    //                    {
    //                        var sw = pp + ((k + p - 1u)/p);
    //                        sw = WHLRNDUP[sw];
    //                        k = (sw - pp)*p - k;
    //                    }
    //                }
    //                else k -= i;
    //                var pd = p/15;
    //                for (ulong l = k/15u + (ulong) strt*4u, lw = ((ulong) WHLNDX[pp] << 3) + WHLNDX[k%15]; l < (ulong) (strt + cnt)*4u;)
    //                {
    //                    var st = WHLST[lw];
    //                    b[l >> 2] |= (ulong) st.msk << (int) ((l & 3) << 3);
    //                    l += st.mlt*pd + st.xtr;
    //                    lw = st.nxt;
    //                }
    //            }
    //            if ((bm << 1) == 0u)
    //            {
    //                v = bpbuf[++bi];
    //                bm = 1u;
    //            }
    //        }
    //    }
    //    static fastprimesSoE()
    //    {
    //        for (var x = 0; x < 8; ++x)
    //        {
    //            var p = 7 + 2*WHLPOS[x];
    //            var i = ((p*p - 7)/2)%15;
    //            p %= 15;
    //            for (var y = 0; y < 8; ++y)
    //            {
    //                var n = WHLNDX[i];
    //                var m = WHLPTRN[(x + y)%8];
    //                var pls = i + m*p;
    //                i = pls%15;
    //                WHLST[x*8 + n] = new wst
    //                    {
    //                        msk = (byte) (1 << n),
    //                        mlt = m,
    //                        xtr = (byte) (pls/15),
    //                        nxt = (byte) (8*x + WHLNDX[i])
    //                    };
    //            }
    //        }
    //        cullpg(0u, bpbuf, 0, bpbuf.Length);
    //    } //init baseprimes
    //    private class nmrtr : IEnumerator<ulong>, IEnumerator, IDisposable
    //    {
    //        private procspc[] ps = new procspc[NUMPROCS];
    //        private ulong[] buf;
    //        private Task dlycullpg(ulong i, ulong[] buf)
    //        {
    //            return Task.Factory.StartNew(() =>
    //                {
    //                    for (var c = 0u; c < CHNKSZ; ++c) cullpg(i + c*PGSZ*60, buf, (int) (c*PGSZ), (int) PGSZ);
    //                });
    //        }
    //        public nmrtr()
    //        {
    //            for (var i = 0u; i < NUMPROCS; ++i)
    //                ps[i] = new procspc
    //                    {
    //                        buf = new ulong[BUFSZ]
    //                    };
    //            for (var i = 1u; i < NUMPROCS; ++i)
    //            {
    //                ps[i].tsk = dlycullpg((i - 1u)*BUFSZBTS, ps[i].buf);
    //            }
    //            buf = ps[0].buf;
    //        }
    //        public ulong Current
    //        {
    //            get { return this._curr; }
    //        }
    //        object IEnumerator.Current
    //        {
    //            get { return this._curr; }
    //        }
    //        private ulong _curr;
    //        private int b = -4;
    //        private ulong i = 0, w = 0;
    //        private ulong v, msk = 0;
    //        public bool MoveNext()
    //        {
    //            if (b < 0)
    //                if (b == -1)
    //                {
    //                    _curr = 7;
    //                    b += (int) BUFSZ;
    //                }
    //                else
    //                {
    //                    if (b++ == -4) this._curr = 2u;
    //                    else this._curr = 7u + ((ulong) b << 1);
    //                    return true;
    //                }
    //            do
    //            {
    //                i += w & 0xF;
    //                if ((w >>= 4) == 0) w = 0x31321212u;
    //                if ((this.msk <<= 1) == 0)
    //                {
    //                    if (++b >= BUFSZ)
    //                    {
    //                        b = 0;
    //                        for (var prc = 0; prc < NUMPROCS - 1; ++prc) ps[prc] = ps[prc + 1];
    //                        ps[NUMPROCS - 1u].buf = buf;
    //                        var low = i + (NUMPROCS - 1u)*BUFSZBTS;
    //                        ps[NUMPROCS - 1u].tsk = dlycullpg(i + (NUMPROCS - 1u)*BUFSZBTS, buf);
    //                        ps[0].tsk.Wait();
    //                        buf = ps[0].buf;
    //                    }
    //                    v = buf[b];
    //                    this.msk = 1;
    //                }
    //            } while ((v & msk) != 0u);
    //            if (_curr > (_curr = 7u + i + i)) return false;
    //            else return true;
    //        }
    //        public void Reset()
    //        {
    //            throw new Exception("Primes enumeration reset not implemented!!!");
    //        }
    //        public void Dispose()
    //        {
    //        }
    //    }

    //    public IEnumerator<ulong> GetEnumerator()
    //    {
    //        return new nmrtr();
    //    }
    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return new nmrtr();
    //    }
    //}
}