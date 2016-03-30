using System;

namespace PeterO.Rand {
    /// <summary>A class that adapts a random byte generator to generate
    /// random numbers in a variety of statistical distributions.
    /// <para>The method descriptions in this class assume the underlying
    /// random byte generator generates uniformly distributed numbers that
    /// are independent of each other.</para>
    /// <para><b>Thread safety:</b> The methods in this class are safe for
    /// concurrent use by multiple threads, as long as the underlying
    /// random byte generator is as well.</para></summary>
  public sealed class RandomGenerator {
    bool haveLastNormal;
    IRandomGen irg;
    double lastNormal;
    object normalLock = new Object();
    public RandomGenerator() : this(new XorShift128Plus()) {
    }
    public RandomGenerator(IRandomGen irg) {
      this.irg = irg;
    }

    /// <summary>Returns either true or false, depending on the given
    /// probability.</summary>
    /// <param name='p'>A probability from 0 through 1. 0 means always
    /// false, and 1 means always true.</param>
    /// <returns>A Boolean object.</returns>
    public bool Bernoulli(double p) {
      if (p < 0) {
        throw new ArgumentException("p (" + p + ") is less than " + 0);
      }
      if (p > 1) {
        throw new ArgumentException("p (" + p + ") is more than " + 1);
      }
      return Uniform() < p;
    }

    /// <summary>Returns either true or false at a 50% chance
    /// each.</summary>
    /// <returns>A Boolean object.</returns>
    public bool Bernoulli() {
      return UniformInt(2) == 0;
    }

    /// <summary>Conceptually, generates either 1 or 0 the given number of
    /// times, where either number is equally likely, and counts the number
    /// of 1's generated.</summary>
    /// <param name='trials'>Another 32-bit signed integer.</param>
    /// <returns>A 32-bit signed integer.</returns>
    public int Binomial(int trials) {
      return Binomial(trials, 0.5);
    }

    /// <summary>Conceptually, generates either 1 or 0 the given number of
    /// times, where a 1 is generated at the given probability, and counts
    /// the number of 1's generated.</summary>
    /// <param name='trials'>Another 32-bit signed integer.</param>
    /// <param name='p'>The probability for each trial to succeed, from 0
    /// (never) to 1 (always).</param>
    /// <returns>The number of successes in a given number of
    /// trials.</returns>
    public int Binomial(int trials, double p) {
      if (p < 0) {
        throw new ArgumentException("p (" + p + ") is less than " + 0);
      }
      if (p > 1) {
        throw new ArgumentException("p (" + p + ") is more than " + 1);
      }
      if ((trials) <= -1) {
        throw new ArgumentException("trials (" + trials +
               ") is not greater than " + (-1));
      }
      if (trials == 0 || p == 1.0) {
        return trials;
      }
      var count = 0;
      if (p == 0.5) {
        var bytes = new byte[1];
        for (int i = 0; i < trials && i >= 0;) {
          irg.GetBytes(bytes, 0, 1);
          int b = bytes[0];
          while (i < trials && i >= 0) {
            if ((b & 1) == 1) {
              ++count;
            }
            b >>= 1;
            ++i;
          }
        }
      } else {
        for (int i = 0; i < trials && i >= 0; ++i) {
          if (Uniform() < p) {
            ++count;
          }
        }
      }
      return count;
    }

    /// <summary>Generates a random number that is the sum of the squares
    /// of "df" normally-distributed random numbers with a mean of 0 and a
    /// standard deviation of 1.</summary>
    /// <param name='df'>Not documented yet.</param>
    /// <returns>A 64-bit floating-point number.</returns>
    public double ChiSquared(double df) {
      if (df <= 0) {
        throw new ArgumentException("df (" + df + ") is not greater than " + 0);
      }
      return Gamma(df / 2, 2);
    }

    /// <summary>Not documented yet.</summary>
    /// <returns>A 64-bit floating-point number.</returns>
    public double Exponential() {
      return -Math.Log(NonZeroUniform());
    }

    /// <summary>Not documented yet.</summary>
    /// <param name='a'>Another 64-bit floating-point number.</param>
    /// <param name='b'>A 64-bit floating-point number. (3).</param>
    /// <returns>A 64-bit floating-point number.</returns>
    public double Gamma(double a, double b) {
      if (b <= 0) {
        throw new ArgumentException("b (" + b + ") is not greater than " + 0);
      }
      return Gamma(a) * b;
    }

    /// <summary>Not documented yet.</summary>
    /// <param name='a'>Another 64-bit floating-point number.</param>
    /// <returns>A 64-bit floating-point number.</returns>
    public double Gamma(double a) {
      if ((a) <= -1) {
        throw new ArgumentException("a (" + a + ") is not greater than " +
            (-1));
      }
      double v, x, u, x2, d, c;
      d = (a < 1 ? 1 + a : a) - 1 / 3;
      c = 1 / Math.Sqrt(9 * d);
      do {
        do {
          x = this.Normal();
          v = Math.Pow(c * x + 1, 3);
        } while (v <= 0);
        u = this.Uniform();
        x2 = Math.Pow(x, 2);
      } while (u >= 1 - (0.0331 * x2 * x2) &&
               Math.Log(u) >= 0.5 * x2 + d * (1 - v + Math.Log(v)));
      if (a < 1) {
        return d * v * Math.Exp(this.Exponential() / -a);
      } else {
        return d * v;
      }
    }

    /// <summary>Conceptually, generates either 1 or 0 until a 1 is
    /// generated, and counts the number of 0's generated. Either number
    /// has an equal probability of being generated.</summary>
    /// <returns>The number of failures until a success happens.</returns>
    public int Geometric() {
      return NegativeBinomial(1, 0.5);
    }

    /// <summary>Conceptually, generates either 1 or 0 until a 1 is
    /// generated, and counts the number of 0's generated. A 1 is generated
    /// at the given probability.</summary>
    /// <param name='p'>A 64-bit floating-point number.</param>
    /// <returns>The number of failures until a success happens.</returns>
    public int Geometric(double p) {
      return NegativeBinomial(1, p);
    }

    /// <summary>Conceptually, given a set of tokens, some of which are
    /// labeled 1 and the others labeled 0, draws "trials" tokens and then
    /// counts the number of 1's drawn.</summary>
    /// <param name='trials'>Not documented yet.</param>
    /// <param name='ones'>Not documented yet.</param>
    /// <param name='count'>Not documented yet. (3).</param>
    /// <returns>A 32-bit signed integer.</returns>
    public int Hypergeometric(int trials, int ones, int count) {
      if (ones < 0) {
        throw new ArgumentException("ones (" + ones + ") is less than " +
            0);
      }
      if (ones > count) {
        throw new ArgumentException("ones (" + ones + ") is more than " +
          count);
      }
      if (count < 0) {
        throw new ArgumentException("count (" + count +
          ") is less than " + 0);
      }
      if (trials < 0) {
        throw new ArgumentException("trials (" + trials +
          ") is less than " + 0);
      }
      if (trials > count) {
        throw new ArgumentException("trials (" + trials +
          ") is more than " + count);
      }
      var ret = 0;
      for (var i = 0; i < trials && ones > 0; ++i) {
        if (UniformInt(count) < ones) {
          --ones;
          ++ret;
        }
        --count;
      }
      return ret;
    }

    /// <summary>Generates a logarithmic normally-distributed number with
    /// the given mean and standard deviation.</summary>
    /// <param name='mean'>Not documented yet.</param>
    /// <param name='sd'>Not documented yet.</param>
    /// <returns>A 64-bit floating-point number.</returns>
    public double LogNormal(double mean, double sd) {
      return Math.Exp((Normal() * sd) + mean);
    }

    /// <summary>Conceptually, generates either 1 or 0 until the given
    /// number of 1's are generated, and counts the number of 0's
    /// generated. A 1 is generated at the given probability.</summary>
    /// <param name='trials'>The number of 1's to generate before the
    /// process stops.</param>
    /// <param name='p'>The probability for each trial to succeed, from 0
    /// (never) to 1 (always).</param>
    /// <returns>The number of 0's generated. Returns Int32.MaxValue if
    /// <paramref name='p'/> is 0.</returns>
    public int NegativeBinomial(int trials, double p) {
      if (p < 0) {
        throw new ArgumentException("p (" + p + ") is less than " + 0);
      }
      if (p > 1) {
        throw new ArgumentException("p (" + p + ") is more than " + 1);
      }
      if ((trials) <= -1) {
        throw new ArgumentException("trials (" + trials +
               ") is not greater than " + (-1));
      }
      if (trials == 0 || p == 1.0) {
        return 0;
      }
      if (p == 0.0) {
        return Int32.MaxValue;
      }
      var count = 0;
      if (p == 0.5) {
        var bytes = new byte[1];
        while (true) {
          irg.GetBytes(bytes, 0, 1);
          int b = bytes[0];
          for (int i = 0; i < 8; ++i) {
            if ((b & 1) == 1) {
              --trials;
              if (trials <= 0) {
                return count;
              }
            } else {
              count = checked(count + 1);
            }
            b >>= 1;
            ++i;
          }
        }
      } else {
        while (true) {
          if (Uniform() < p) {
            --trials;
            if (trials <= 0) {
              return count;
            }
          } else {
            count = checked(count + 1);
          }
        }
      }
    }

    /// <summary>Conceptually, generates either 1 or 0 the given number of
    /// times until the given number of 1's are generated, and counts the
    /// number of 0's generated. Either number has an equal probability of
    /// being generated.</summary>
    /// <param name='trials'>The number of 1's to generate before the
    /// process stops.</param>
    /// <returns>The number of 0's generated. Returns Int32.MaxValue if "p"
    /// is 0.</returns>
    public int NegativeBinomial(int trials) {
      return NegativeBinomial(trials, 0.5);
    }
    // The Normal, Exponential, Poisson, and
    // single-argument Gamma methods were adapted
    // from "Seedable random number generator functions",
    // a public-domain JavaScript file.

    /// <summary>Generates a normally-distributed number with mean 0 and
    /// standard deviation 1.</summary>
    /// <returns>A 64-bit floating-point number.</returns>
    public double Normal() {
      lock (normalLock) {
        if (haveLastNormal) {
          haveLastNormal = false;
          return lastNormal;
        }
      }
      double x = NonZeroUniform();
      double y = Uniform();
      double s = Math.Sqrt(-2 * Math.Log(x));
      double t = 2 * Math.PI * y;
      double otherNormal = s * Math.Sin(t);
      lock (normalLock) {
        lastNormal = otherNormal;
      }
      return s * Math.Cos(t);
    }

    /// <summary>Generates a normally-distributed number with the given
    /// mean and standard deviation.</summary>
    /// <param name='mean'>Not documented yet.</param>
    /// <param name='sd'>Not documented yet.</param>
    /// <returns>A 64-bit floating-point number.</returns>
    public double Normal(double mean, double sd) {
      return (Normal() * sd) + mean;
    }

    /// <summary>Generates a random integer such that the average of random
    /// numbers approaches the given mean number when this method is called
    /// repeatedly with the same mean.</summary>
    /// <param name='mean'>The expected mean of the random numbers.</param>
    /// <returns>A 32-bit signed integer.</returns>
    public int Poisson(double mean) {
      if (mean < 0) {
        throw new ArgumentException("mean (" + mean +
          ") is less than " + 0);
      }
      double l = Math.Exp(-mean);
      var k = 0;
      double p = 0;
      do {
        ++k;
        p *= Uniform();
      } while (p > l);
      return k - 1;
    }

    /// <param name='min'>Not documented yet.</param>
    /// <param name='max'>Not documented yet.</param>
    /// <returns>A 64-bit floating-point number.</returns>
    public double Uniform(double min, double max) {
      if (min >= max) {
        throw new ArgumentException("min (" + min + ") is not less than " +
            max);
      }
      return min + (max - min) * Uniform();
    }

    public double Uniform(double max) {
      return Uniform(0.0, max);
    }

    /// <returns>A 64-bit floating-point number.</returns>
    public double Uniform() {
      var b = new byte[7];
      irg.GetBytes(b, 0, 7);
      long lb = ((long)b[0] & 0xffL);
      lb |= ((long)b[1] & 0xffL) << 8;
      lb |= ((long)b[2] & 0xffL) << 16;
      lb |= ((long)b[3] & 0xffL) << 24;
      lb |= ((long)b[4] & 0xffL) << 32;
      lb |= ((long)b[5] & 0xffL) << 40;
      lb |= ((long)b[6] & 0xfL) << 48;
      lb |= 0x3ffL << 52;
      return BitConverter.Int64BitsToDouble(lb) - 1.0;
    }

    public double UniformSingle() {
      var b = new byte[3];
      irg.GetBytes(b, 0, 3);
      int lb = ((int)b[0] & 0xff);
      lb |= ((int)b[1] & 0xff) << 8;
      lb |= ((int)b[2] & 0x7f) << 16;
      lb |= 0x7f << 23;
      return BitConverter.ToSingle(
       BitConverter.GetBytes(lb),
       0) - 1.0;
    }

    /// <param name='minInclusive'>Not documented yet.</param>
    /// <param name='maxExclusive'>Not documented yet.</param>
    /// <returns>A 32-bit signed integer.</returns>
    public int UniformInt(int minInclusive, int maxExclusive) {
      if (minInclusive > maxExclusive) {
  throw new ArgumentException("minInclusive (" + minInclusive +
    ") is more than " + maxExclusive);
}
      if (minInclusive >= 0) {
        return minInclusive + UniformInt(maxExclusive-minInclusive);
      } else {
        long diff = maxExclusive-minInclusive;
        if (diff <= Int32.MaxValue) {
          return minInclusive + UniformInt((int)diff);
        } else {
          return (int)(minInclusive + UniformLong(diff));
        }
      }
    }

    /// <param name='minInclusive'>Not documented yet.</param>
    /// <param name='maxExclusive'>Not documented yet.</param>
    /// <returns>A 64-bit signed integer.</returns>
    public long UniformLong(long minInclusive, long maxExclusive) {
      if (minInclusive > maxExclusive) {
  throw new ArgumentException("minInclusive (" + minInclusive +
    ") is more than " + maxExclusive);
}
      if (minInclusive >= 0) {
        return minInclusive + UniformLong(maxExclusive-minInclusive);
      } else {
        // TODO
        throw new NotImplementedException();
      }
    }

    /// <param name='maxExclusive'>Not documented yet.</param>
    /// <returns>A 32-bit signed integer.</returns>
    public int UniformInt(int maxExclusive) {
      if (maxExclusive < 0) {
  throw new ArgumentException("maxExclusive (" + maxExclusive +
    ") is less than " + 0);
}
      if (maxExclusive <= 0) {
 return 0;
}
      var b = new byte[4];
      switch (maxExclusive) {
        case 2: {
            irg.GetBytes(b, 0, 1);
            return (b[0] & 1);
          }
        case 256: {
            irg.GetBytes(b, 0, 1);
            return ((int)b[0] & 1);
          }
        default: {
            while (true) {
              var ib = 0;
              if (maxExclusive == 0x1000000) {
                irg.GetBytes(b, 0, 3);
                ib = (b[0] & 0xff);
                ib |= (b[1] & 0xff) << 8;
                ib |= (b[2] & 0xff) << 16;
                return ib;
              }
              if (maxExclusive == 0x10000) {
                irg.GetBytes(b, 0, 2);
                ib = (b[0] & 0xff);
                ib |= (b[1] & 0xff) << 8;
                return ib;
              }
              int maxexc;
              maxexc = (maxExclusive <= 100) ? 2147483600 :
                ((Int32.MaxValue / maxExclusive) * maxExclusive);
              while (true) {
                irg.GetBytes(b, 0, 4);
                ib = (b[0] & 0xff);
                ib |= (b[1] & 0xff) << 8;
                ib |= (b[2] & 0xff) << 16;
                ib |= (b[3] & 0x7f) << 24;
                if (ib < maxexc) {
                 return ib % maxExclusive;
                }
              }
            }
          }
      }
    }

    /// <param name='maxExclusive'>Not documented yet.</param>
    /// <returns>A 64-bit signed integer.</returns>
    public long UniformLong(long maxExclusive) {
      if (maxExclusive < 0) {
  throw new ArgumentException("maxExclusive (" + maxExclusive +
    ") is less than " + 0);
}
      if (maxExclusive <= Int32.MaxValue) {
        return UniformInt((int)maxExclusive);
      }
      long lb = 0;
      long maxexc;
      var b = new byte[8];
      maxexc = (Int64.MaxValue / maxExclusive) * maxExclusive;
      while (true) {
        irg.GetBytes(b, 0, 8);
        lb = (b[0] & 0xffL);
        lb |= (b[1] & 0xffL) << 8;
        lb |= (b[2] & 0xffL) << 16;
        lb |= (b[3] & 0xffL) << 24;
        lb |= (b[4] & 0xffL) << 32;
        lb |= (b[5] & 0xffL) << 40;
        lb |= (b[6] & 0xffL) << 48;
        lb |= (b[7] & 0x7fL) << 56;
        if (lb < maxexc) {
          return lb % maxExclusive;
        }
      }
    }

    private double NonZeroUniform() {
      var b = new byte[7];
      long lb = 0;
      do {
        irg.GetBytes(b, 0, 7);
        lb = (b[0] & 0xffL);
        lb |= (b[1] & 0xffL) << 8;
        lb |= (b[2] & 0xffL) << 16;
        lb |= (b[3] & 0xffL) << 24;
        lb |= (b[4] & 0xffL) << 32;
        lb |= (b[5] & 0xffL) << 40;
        lb |= (b[6] & 0xfL) << 48;
      } while (lb == 0);
      lb |= 0x3ffL << 52;
      return BitConverter.Int64BitsToDouble(lb) - 1.0;
    }
  }
}
