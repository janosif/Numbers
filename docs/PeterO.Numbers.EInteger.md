## PeterO.Numbers.EInteger

    public sealed class EInteger :
        System.IComparable,
        System.IEquatable

Represents an arbitrary-precision integer. (The "E" stands for "extended", and has this prefix to group it with the other classes common to this library, particularly EDecimal, EFloat, and ERational.)Instances of this class are immutable, so they are inherently safe for use by multiple threads. Multiple instances of this object with the same value are interchangeable, but they should be compared using the "Equals" method rather than the "==" operator.

Represents an arbitrary-precision integer. (The "E" stands for "extended", and has this prefix to group it with the other classes common to this library, particularly EDecimal, EFloat, and ERational.)Instances of this class are immutable, so they are inherently safe for use by multiple threads. Multiple instances of this object with the same value are interchangeable, but they should be compared using the "Equals" method rather than the "==" operator.

### IsEven

    public bool IsEven { get; }

Gets a value indicating whether this value is even.

<b>Returns:</b>

 `true`  if this value is even; otherwise,  `false` .

### IsPowerOfTwo

    public bool IsPowerOfTwo { get; }

Gets a value indicating whether this object's value is a power of two.

<b>Returns:</b>

 `true`  if this object's value is a power of two; otherwise,  `false` .

### IsZero

    public bool IsZero { get; }

Gets a value indicating whether this value is 0.

<b>Returns:</b>

 `true`  if this value is 0; otherwise,  `false` .

### One

    public static PeterO.Numbers.EInteger One { get; }

Gets the number 1 as an arbitrary-precision integer.

<b>Returns:</b>

The number 1 as an arbitrary-precision integer.

### Sign

    public int Sign { get; }

Gets the sign of this object's value.

<b>Returns:</b>

0 if this value is zero; -1 if this value is negative, or 1 if this value is positive.

### Ten

    public static PeterO.Numbers.EInteger Ten { get; }

Gets the number 10 as an arbitrary-precision integer.

<b>Returns:</b>

The number 10 as an arbitrary-precision integer.

### Zero

    public static PeterO.Numbers.EInteger Zero { get; }

Gets a value not documented yet.

<b>Returns:</b>

A value not documented yet.

### Abs

    public PeterO.Numbers.EInteger Abs();

Returns the absolute value of this object's value.

<b>Return Value:</b>

This object's value with the sign removed.

### Add

    public PeterO.Numbers.EInteger Add(
        PeterO.Numbers.EInteger bigintAugend);

Adds this object and another object.

<b>Parameters:</b>

 * <i>bigintAugend</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

The sum of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintAugend</i>
 is null.

### And

    public static PeterO.Numbers.EInteger And(
        PeterO.Numbers.EInteger a,
        PeterO.Numbers.EInteger b);

Does an AND operation between two arbitrary-precision integer values.

Each arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) for the purposes of this operator.

<b>Parameters:</b>

 * <i>a</i>: The first arbitrary-precision integer.

 * <i>b</i>: The second arbitrary-precision integer.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>a</i>
 or  <i>b</i>
 is null.

### AsInt32Checked

    public int AsInt32Checked();

<b>Deprecated.</b> Renamed to ToInt32Checked.

Converts this object's value to a 32-bit signed integer, throwing an exception if it can't fit.

<b>Return Value:</b>

A 32-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 32-bit signed integer.

### AsInt32Unchecked

    public int AsInt32Unchecked();

<b>Deprecated.</b> Renamed to ToInt32Unchecked.

Converts this object's value to a 32-bit signed integer. If the value can't fit in a 32-bit integer, returns the lower 32 bits of this object's two' s-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) (in which case the return value might have a different sign than this object's value).

<b>Return Value:</b>

A 32-bit signed integer.

### AsInt64Checked

    public long AsInt64Checked();

<b>Deprecated.</b> Renamed to ToInt64Checked.

Converts this object's value to a 64-bit signed integer, throwing an exception if it can't fit.

<b>Return Value:</b>

A 64-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 64-bit signed integer.

### AsInt64Unchecked

    public long AsInt64Unchecked();

<b>Deprecated.</b> Renamed to ToInt64Unchecked.

Converts this object's value to a 64-bit signed integer. If the value can't fit in a 64-bit integer, returns the lower 64 bits of this object's two' s-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) (in which case the return value might have a different sign than this object's value).

<b>Return Value:</b>

A 64-bit signed integer.

### CanFitInInt32

    public bool CanFitInInt32();

Returns whether this object's value can fit in a 32-bit signed integer.

<b>Return Value:</b>

 `true`  if this object's value is from -2147483648 through 2147483647; otherwise,  `false` .

### CanFitInInt64

    public bool CanFitInInt64();

Returns whether this object's value can fit in a 64-bit signed integer.

<b>Return Value:</b>

 `true`  if this object's value is from -9223372036854775808 through 9223372036854775807; otherwise,  `false` .

### CompareTo

    public sealed int CompareTo(
        PeterO.Numbers.EInteger other);

Compares an arbitrary-precision integer with this instance.

<b>Parameters:</b>

 * <i>other</i>: The parameter  <i>other</i>
 is not documented yet.

<b>Return Value:</b>

Zero if the values are equal; a negative number if this instance is less, or a positive number if this instance is greater.

### Divide

    public PeterO.Numbers.EInteger Divide(
        PeterO.Numbers.EInteger bigintDivisor);

Divides this instance by the value of an arbitrary-precision integer. The result is rounded down (the fractional part is discarded). Except if the result is 0, it will be negative if this object is positive and the other is negative, or vice versa, and will be positive if both are positive or both are negative.

<b>Parameters:</b>

 * <i>bigintDivisor</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

The quotient of the two objects.

<b>Exceptions:</b>

 * System.DivideByZeroException:
The parameter <i>bigintDivisor</i>
 is zero.

 * System.ArgumentNullException:
The parameter <i>bigintDivisor</i>
 is null.

### DivRem

    public PeterO.Numbers.EInteger[] DivRem(
        PeterO.Numbers.EInteger divisor);

Divides this object by another arbitrary-precision integer and returns the quotient and remainder.

<b>Parameters:</b>

 * <i>divisor</i>: The number to divide by.

<b>Return Value:</b>

An array with two arbitrary-precision integers: the first is the quotient, and the second is the remainder.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter divisor is null.

 * System.DivideByZeroException:
The parameter divisor is 0.

 * System.DivideByZeroException:
Attempted to divide by zero.

### Equals

    public override bool Equals(
        object obj);

Determines whether this object and another object are equal and have the same type.

<b>Parameters:</b>

 * <i>obj</i>: An arbitrary object.

<b>Return Value:</b>

 `true`  if this object and another object are equal; otherwise,  `false` .

### Equals

    public sealed bool Equals(
        PeterO.Numbers.EInteger other);

Determines whether this object and another object are equal.

<b>Parameters:</b>

 * <i>other</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

 `true`  if this object and another object are equal; otherwise,  `false` .

### FromByte

    public static PeterO.Numbers.EInteger FromByte(
        byte inputByte);

Converts a byte (from 0 to 255) to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>inputByte</i>: The number to convert as a byte (from 0 to 255).

<b>Return Value:</b>

This number's value as an arbitrary-precision integer.

### FromBytes

    public static PeterO.Numbers.EInteger FromBytes(
        byte[] bytes,
        bool littleEndian);

Initializes an arbitrary-precision integer from an array of bytes.

<b>Parameters:</b>

 * <i>bytes</i>: A byte array consisting of the two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) of the arbitrary-precision integer to create. The byte array is encoded using the following rules:

 * Positive numbers have the first byte's highest bit cleared, and negative numbers have the bit set.

 * The last byte contains the lowest 8-bits, the next-to-last contains the next lowest 8 bits, and so on. For example, the number 300 can be encoded as  `0x01, 0x2C`  and 200 as  `0x00,
            0xC8` . (Note that the second example contains a set high bit in `0xC8` , so an additional 0 is added at the start to ensure it's interpreted as positive.)

 * To encode negative numbers, take the absolute value of the number, subtract by 1, encode the number into bytes, and toggle each bit of each byte. Any further bits that appear beyond the most significant bit of the number will be all ones. For example, the number -450 can be encoded as  `0xfe, 0x70`  and -52869 as `0xff, 0x31, 0x7B` . (Note that the second example contains a cleared high bit in  `0x31, 0x7B` , so an additional 0xff is added at the start to ensure it's interpreted as negative.)

For little-endian, the byte order is reversed from the byte order just discussed.

.

 * <i>littleEndian</i>: If true, the byte order is little-endian, or least-significant-byte first. If false, the byte order is big-endian, or most-significant-byte first.

<b>Return Value:</b>

An arbitrary-precision integer. Returns 0 if the byte array's length is 0.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bytes</i>
 is null.

### FromInt16

    public static PeterO.Numbers.EInteger FromInt16(
        short inputInt16);

Converts a 16-bit signed integer to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>inputInt16</i>: The number to convert as a 16-bit signed integer.

<b>Return Value:</b>

This number's value as an arbitrary-precision integer.

### FromInt32

    public static PeterO.Numbers.EInteger FromInt32(
        int intValue);

Converts a 32-bit signed integer to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>intValue</i>: A 32-bit signed integer.

<b>Return Value:</b>

An arbitrary-precision integer with the same value as the 64-bit number.

### FromInt64

    public static PeterO.Numbers.EInteger FromInt64(
        long longerValue);

Converts a 64-bit signed integer to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>longerValue</i>: A 64-bit signed integer.

<b>Return Value:</b>

An arbitrary-precision integer with the same value as the 64-bit number.

### FromRadixString

    public static PeterO.Numbers.EInteger FromRadixString(
        string str,
        int radix);

Not documented yet.

<b>Parameters:</b>

 * <i>str</i>: The parameter  <i>str</i>
 is not documented yet.

 * <i>radix</i>: The parameter  <i>radix</i>
 is not documented yet.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter  <i>str</i>
 is null.

### FromRadixSubstring

    public static PeterO.Numbers.EInteger FromRadixSubstring(
        string str,
        int radix,
        int index,
        int endIndex);

Converts a portion of a string to an arbitrary-precision integer in a given radix.

<b>Parameters:</b>

 * <i>str</i>: A text string. The desired portion of the string must contain only characters allowed by the given radix, except that it may start with a minus sign ("-", U+002D) to indicate a negative number. The desired portion is not allowed to contain white space characters, including spaces.

 * <i>radix</i>: A base from 2 to 36. Depending on the radix, the string can use the basic digits 0 to 9 (U+0030 to U+0039) and then the basic letters A to Z (U+0041 to U+005A). For example, 0-9 in radix 10, and 0-9, then A-F in radix 16.

 * <i>index</i>: The index of the string that starts the string portion.

 * <i>endIndex</i>: The index of the string that ends the string portion. The length will be index + endIndex - 1.

<b>Return Value:</b>

An arbitrary-precision integer with the same value as given in the string portion.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.ArgumentException:
The parameter <i>index</i>
 is less than 0,  <i>endIndex</i>
 is less than 0, or either is greater than the string's length, or  <i>endIndex</i>
 is less than <i>index</i>
.

 * System.FormatException:
The string portion is empty or in an invalid format.

### FromSByte

    public static PeterO.Numbers.EInteger FromSByte(
        sbyte inputSByte);

Converts an 8-bit signed integer to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>inputSByte</i>: The number to convert as an 8-bit signed integer.

<b>Return Value:</b>

This number's value as an arbitrary-precision integer.

### FromString

    public static PeterO.Numbers.EInteger FromString(
        string str);

Converts a string to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>str</i>: A text string. The string must contain only basic digits 0 to 9 (U+0030 to U+0039), except that it may start with a minus sign ("-", U+002D) to indicate a negative number. The string is not allowed to contain white space characters, including spaces.

<b>Return Value:</b>

An arbitrary-precision integer with the same value as given in the string.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.FormatException:
The parameter  <i>str</i>
 is in an invalid format.

### FromSubstring

    public static PeterO.Numbers.EInteger FromSubstring(
        string str,
        int index,
        int endIndex);

Converts a portion of a string to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>str</i>: A text string. The desired portion of the string must contain only basic digits 0 to 9 (U+0030 to U+0039), except that it may start with a minus sign ("-", U+002D) to indicate a negative number. The desired portion is not allowed to contain white space characters, including spaces.

 * <i>index</i>: The index of the string that starts the string portion.

 * <i>endIndex</i>: The index of the string that ends the string portion. The length will be index + endIndex - 1.

<b>Return Value:</b>

An arbitrary-precision integer with the same value as given in the string portion.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>str</i>
 is null.

 * System.ArgumentException:
The parameter <i>index</i>
 is less than 0,  <i>endIndex</i>
 is less than 0, or either is greater than the string's length, or  <i>endIndex</i>
 is less than <i>index</i>
.

 * System.FormatException:
The string portion is empty or in an invalid format.

### FromUInt16

    public static PeterO.Numbers.EInteger FromUInt16(
        ushort inputUInt16);

Converts a 16-bit unsigned integer to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>inputUInt16</i>: The number to convert as a 16-bit unsigned integer.

<b>Return Value:</b>

This number's value as an arbitrary-precision integer.

### FromUInt32

    public static PeterO.Numbers.EInteger FromUInt32(
        uint inputUInt32);

Converts a 32-bit signed integer to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>inputUInt32</i>: The number to convert as a 32-bit signed integer.

<b>Return Value:</b>

This number's value as an arbitrary-precision integer.

### FromUInt64

    public static PeterO.Numbers.EInteger FromUInt64(
        ulong ulongValue);

Converts a 64-bit unsigned integer to an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>ulongValue</i>: The number to convert as a 64-bit unsigned integer.

<b>Return Value:</b>

The value of  <i>ulongValue</i>
 as an arbitrary-precision integer.

### Gcd

    public PeterO.Numbers.EInteger Gcd(
        PeterO.Numbers.EInteger bigintSecond);

Returns the greatest common divisor of two integers. The greatest common divisor (GCD) is also known as the greatest common factor (GCF).

<b>Parameters:</b>

 * <i>bigintSecond</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintSecond</i>
 is null.

### GetBits

    public long GetBits(
        int index,
        int numberBits);

Retrieves bits from this integer's two' s-complement form.

<b>Parameters:</b>

 * <i>index</i>: Zero-based index of the first bit to retrieve, where 0 is the least-significant bit of the number.

 * <i>numberBits</i>: The number of bits to retrieve, starting with the first. Must be from 0 through 64.

<b>Return Value:</b>

A 64-bit signed integer containing the bits from this integer's two' s-complement form. The least significant bit is the first bit, and any unused bits are set to 0.

### GetDigitCount

    public int GetDigitCount();

Not documented yet.

<b>Return Value:</b>

A 32-bit signed integer.

### GetHashCode

    public override int GetHashCode();

Returns the hash code for this instance. No application or process IDs are used in the hash code calculation.

<b>Return Value:</b>

A 32-bit signed integer.

### GetLowBit

    public int GetLowBit();

Gets the lowest set bit in this number's absolute value. (This will also be the lowest set bit in the number's two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md)).).

<b>Return Value:</b>

The lowest bit set in the number, starting at 0. Returns -1 if this value is 0 or odd.

### GetLowBitAsEInteger

    public PeterO.Numbers.EInteger GetLowBitAsEInteger();

Gets the lowest set bit in this number's absolute value. (This will also be the lowest set bit in the number's two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md)).).

<b>Return Value:</b>

The lowest bit set in the number, starting at 0. Returns -1 if this value is 0 or odd.

### GetSignedBit

    public bool GetSignedBit(
        int index);

Returns whether a bit is set in the two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) of this object' s value.

<b>Parameters:</b>

 * <i>index</i>: Zero based index of the bit to test. 0 means the least significant bit.

<b>Return Value:</b>

 `true`  if a bit is set in the two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) of this object' s value; otherwise,  `false` .

### GetSignedBitLength

    public int GetSignedBitLength();

Finds the minimum number of bits needed to represent this object's value, except for its sign. If the value is negative, finds the number of bits in the value equal to this object's absolute value minus 1.

<b>Return Value:</b>

The number of bits in this object's value. Returns 0 if this object's value is 0 or negative 1.

### GetUnsignedBit

    public bool GetUnsignedBit(
        int index);

Returns whether a bit is set in this number's absolute value.

<b>Parameters:</b>

 * <i>index</i>: Zero based index of the bit to test. 0 means the least significant bit.

<b>Return Value:</b>

 `true`  if a bit is set in this number's absolute value.

### GetUnsignedBitLength

    public int GetUnsignedBitLength();

Finds the minimum number of bits needed to represent this number's absolute value.

<b>Return Value:</b>

The number of bits in this object's value. Returns 0 if this object's value is 0, and returns 1 if the value is negative 1.

### GetUnsignedBitLengthAsEInteger

    public PeterO.Numbers.EInteger GetUnsignedBitLengthAsEInteger();

Finds the minimum number of bits needed to represent this number's absolute value.

<b>Return Value:</b>

The number of bits in this object's value. Returns 0 if this object's value is 0, and returns 1 if the value is negative 1.

### Mod

    public PeterO.Numbers.EInteger Mod(
        PeterO.Numbers.EInteger divisor);

Finds the modulus remainder that results when this instance is divided by the value of an arbitrary-precision integer. The modulus remainder is the same as the normal remainder if the normal remainder is positive, and equals divisor plus normal remainder if the normal remainder is negative.

<b>Parameters:</b>

 * <i>divisor</i>: A divisor greater than 0 (the modulus).

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArithmeticException:
The parameter <i>divisor</i>
 is negative.

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

### ModPow

    public PeterO.Numbers.EInteger ModPow(
        PeterO.Numbers.EInteger pow,
        PeterO.Numbers.EInteger mod);

Calculates the remainder when an arbitrary-precision integer raised to a certain power is divided by another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>pow</i>: Another arbitrary-precision integer.

 * <i>mod</i>: An arbitrary-precision integer. (3).

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>pow</i>
 or  <i>mod</i>
 is null.

### ModPow

    public static PeterO.Numbers.EInteger ModPow(
        PeterO.Numbers.EInteger bigintValue,
        PeterO.Numbers.EInteger pow,
        PeterO.Numbers.EInteger mod);

Calculates the remainder when an arbitrary-precision integer raised to a certain power is divided by another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>bigintValue</i>: The parameter  <i>bigintValue</i>
 is not documented yet.

 * <i>pow</i>: The parameter  <i>pow</i>
 is not documented yet.

 * <i>mod</i>: The parameter  <i>mod</i>
 is not documented yet.

<b>Return Value:</b>

The value (  <i>bigintValue</i>
 ^  <i>pow</i>
 )%  <i>mod</i>
.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintValue</i>
 is null.

### Multiply

    public PeterO.Numbers.EInteger Multiply(
        PeterO.Numbers.EInteger bigintMult);

Multiplies this instance by the value of an arbitrary-precision integer object.

<b>Parameters:</b>

 * <i>bigintMult</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

The product of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigintMult</i>
 is null.

### Negate

    public PeterO.Numbers.EInteger Negate();

Gets the value of this object with the sign reversed.

<b>Return Value:</b>

This object's value with the sign reversed.

### Not

    public static PeterO.Numbers.EInteger Not(
        PeterO.Numbers.EInteger valueA);

Returns an arbitrary-precision integer with every bit flipped.

<b>Parameters:</b>

 * <i>valueA</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>valueA</i>
 is null.

### Operator `+`

    public static PeterO.Numbers.EInteger operator +(
        PeterO.Numbers.EInteger bthis,
        PeterO.Numbers.EInteger augend);

Adds an arbitrary-precision integer and an arbitrary-precision integer object.

<b>Parameters:</b>

 * <i>bthis</i>: The parameter  <i>bthis</i>
 is not documented yet.

 * <i>augend</i>: The parameter  <i>augend</i>
 is not documented yet.

<b>Return Value:</b>

The sum of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `&`

    public static PeterO.Numbers.EInteger operator &(
        PeterO.Numbers.EInteger thisValue,
        PeterO.Numbers.EInteger otherValue);

Does an AND operation between two arbitrary-precision integer values.

Each arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) for the purposes of this operator.

<b>Parameters:</b>

 * <i>thisValue</i>: An arbitrary-precision integer.

 * <i>otherValue</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

The result of the operation.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter "a" or "b" is null.

### Operator `|`

    public static PeterO.Numbers.EInteger operator |(
        PeterO.Numbers.EInteger thisValue,
        PeterO.Numbers.EInteger otherValue);

Does an OR operation between two arbitrary-precision integer instances.

Each arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) for the purposes of this operator.

<b>Parameters:</b>

 * <i>thisValue</i>: An arbitrary-precision integer.

 * <i>otherValue</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter "first" or "second" is null.

### Operator `/`

    public static PeterO.Numbers.EInteger operator /(
        PeterO.Numbers.EInteger dividend,
        PeterO.Numbers.EInteger divisor);

Divides an arbitrary-precision integer by the value of an arbitrary-precision integer object.

<b>Parameters:</b>

 * <i>dividend</i>: The number that will be divided by the divisor.

 * <i>divisor</i>: The number to divide by.

<b>Return Value:</b>

The quotient of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>dividend</i>
 is null.

### Operator `^`

    public static PeterO.Numbers.EInteger operator ^(
        PeterO.Numbers.EInteger a,
        PeterO.Numbers.EInteger b);

Finds the exclusive "or" of two arbitrary-precision integer objects.Each arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) for the purposes of this operator.

<b>Parameters:</b>

 * <i>a</i>: The first arbitrary-precision integer.

 * <i>b</i>: The second arbitrary-precision integer.

<b>Return Value:</b>

An arbitrary-precision integer in which each bit is set if it's set in one input integer but not the other.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>a</i>
 or  <i>b</i>
 is null.

### Operator `>`

    public static bool operator >(
        PeterO.Numbers.EInteger thisValue,
        PeterO.Numbers.EInteger otherValue);

Determines whether an arbitrary-precision integer is greater than another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Return Value:</b>

 `true`  if  <i>thisValue</i>
 is greater than  <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `>=`

    public static bool operator >=(
        PeterO.Numbers.EInteger thisValue,
        PeterO.Numbers.EInteger otherValue);

Determines whether an arbitrary-precision integer value is greater than another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Return Value:</b>

 `true`  if  <i>thisValue</i>
 is at least <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `<<`

    public static PeterO.Numbers.EInteger operator <<(
        PeterO.Numbers.EInteger bthis,
        int bitCount);

Not documented yet.

<b>Parameters:</b>

 * <i>bthis</i>: Another arbitrary-precision integer.

 * <i>bitCount</i>: A 32-bit signed integer.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `<`

    public static bool operator <(
        PeterO.Numbers.EInteger thisValue,
        PeterO.Numbers.EInteger otherValue);

Determines whether an arbitrary-precision integer is less than another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Return Value:</b>

 `true`  if  <i>thisValue</i>
 is less than <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `<=`

    public static bool operator <=(
        PeterO.Numbers.EInteger thisValue,
        PeterO.Numbers.EInteger otherValue);

Determines whether an arbitrary-precision integer is less than or equal to another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>thisValue</i>: The first arbitrary-precision integer.

 * <i>otherValue</i>: The second arbitrary-precision integer.

<b>Return Value:</b>

 `true`  if  <i>thisValue</i>
 is up to <i>otherValue</i>
 ; otherwise,  `false` .

### Operator `%`

    public static PeterO.Numbers.EInteger operator %(
        PeterO.Numbers.EInteger dividend,
        PeterO.Numbers.EInteger divisor);

Finds the remainder that results when an arbitrary-precision integer is divided by the value of another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>dividend</i>: The first operand.

 * <i>divisor</i>: The number to divide by.

<b>Return Value:</b>

The remainder of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>dividend</i>
 is null.

### Operator `*`

    public static PeterO.Numbers.EInteger operator *(
        PeterO.Numbers.EInteger operand1,
        PeterO.Numbers.EInteger operand2);

Multiplies an arbitrary-precision integer by the value of an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>operand1</i>: The first operand.

 * <i>operand2</i>: The second operand.

<b>Return Value:</b>

The product of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>operand1</i>
 is null.

### Operator `~`

    public static PeterO.Numbers.EInteger operator ~(
        PeterO.Numbers.EInteger thisValue);

Not documented yet.

<b>Parameters:</b>

 * <i>thisValue</i>: The parameter  <i>thisValue</i>
is not documented yet.

<b>Return Value:</b>

An arbitrary-precision integer.

### Operator `>>`

    public static PeterO.Numbers.EInteger operator >>(
        PeterO.Numbers.EInteger bthis,
        int smallValue);

Shifts the bits of an arbitrary-precision integer to the right.

For this operation, the arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ). Thus, for negative values, the arbitrary-precision integer is sign-extended.

<b>Parameters:</b>

 * <i>bthis</i>: Another arbitrary-precision integer.

 * <i>smallValue</i>: A 32-bit signed integer.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `-`

    public static PeterO.Numbers.EInteger operator -(
        PeterO.Numbers.EInteger bthis,
        PeterO.Numbers.EInteger subtrahend);

Subtracts two arbitrary-precision integer values.

<b>Parameters:</b>

 * <i>bthis</i>: An arbitrary-precision integer.

 * <i>subtrahend</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bthis</i>
 is null.

### Operator `-`

    public static PeterO.Numbers.EInteger operator -(
        PeterO.Numbers.EInteger bigValue);

Negates an arbitrary-precision integer.

<b>Parameters:</b>

 * <i>bigValue</i>: An arbitrary-precision integer to negate.

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>bigValue</i>
 is null.

### Or

    public static PeterO.Numbers.EInteger Or(
        PeterO.Numbers.EInteger first,
        PeterO.Numbers.EInteger second);

Does an OR operation between two arbitrary-precision integer instances.

Each arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) for the purposes of this operator.

<b>Parameters:</b>

 * <i>first</i>: Another arbitrary-precision integer.

 * <i>second</i>: An arbitrary-precision integer. (3).

<b>Return Value:</b>

An arbitrary-precision integer.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>first</i>
 or  <i>second</i>
 is null.

### Pow

    public PeterO.Numbers.EInteger Pow(
        int powerSmall);

Raises an arbitrary-precision integer to a power.

<b>Parameters:</b>

 * <i>powerSmall</i>: The exponent to raise to.

<b>Return Value:</b>

The result. Returns 1 if  <i>powerSmall</i>
 is 0.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter <i>powerSmall</i>
 is less than 0.

### PowBigIntVar

    public PeterO.Numbers.EInteger PowBigIntVar(
        PeterO.Numbers.EInteger power);

Raises an arbitrary-precision integer to a power, which is given as another arbitrary-precision integer.

<b>Parameters:</b>

 * <i>power</i>: The exponent to raise to.

<b>Return Value:</b>

The result. Returns 1 if  <i>power</i>
 is 0.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>power</i>
 is null.

 * System.ArgumentException:
The parameter <i>power</i>
 is less than 0.

### Remainder

    public PeterO.Numbers.EInteger Remainder(
        PeterO.Numbers.EInteger divisor);

Finds the remainder that results when this instance is divided by the value of an arbitrary-precision integer. The remainder is the value that remains when the absolute value of this object is divided by the absolute value of the other object; the remainder has the same sign (positive or negative) as this object.

<b>Parameters:</b>

 * <i>divisor</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

The remainder of the two numbers.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>divisor</i>
 is null.

 * System.DivideByZeroException:
Attempted to divide by zero.

### ShiftLeft

    public PeterO.Numbers.EInteger ShiftLeft(
        int numberBits);

Returns an arbitrary-precision integer with the bits shifted to the left by a number of bits. A value of 1 doubles this value, a value of 2 multiplies it by 4, a value of 3 by 8, a value of 4 by 16, and so on.

<b>Parameters:</b>

 * <i>numberBits</i>: The number of bits to shift. Can be negative, in which case this is the same as shiftRight with the absolute value of numberBits.

<b>Return Value:</b>

An arbitrary-precision integer.

### ShiftRight

    public PeterO.Numbers.EInteger ShiftRight(
        int numberBits);

Returns an arbitrary-precision integer with the bits shifted to the right. For this operation, the arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ). Thus, for negative values, the arbitrary-precision integer is sign-extended.

<b>Parameters:</b>

 * <i>numberBits</i>: Number of bits to shift right.

<b>Return Value:</b>

An arbitrary-precision integer.

### Sqrt

    public PeterO.Numbers.EInteger Sqrt();

Finds the square root of this instance's value, rounded down.

<b>Return Value:</b>

The square root of this object's value. Returns 0 if this value is 0 or less.

### SqrtRem

    public PeterO.Numbers.EInteger[] SqrtRem();

Calculates the square root and the remainder.

<b>Return Value:</b>

An array of two arbitrary-precision integers: the first integer is the square root, and the second is the difference between this value and the square of the first integer. Returns two zeros if this value is 0 or less, or one and zero if this value equals 1.

### Subtract

    public PeterO.Numbers.EInteger Subtract(
        PeterO.Numbers.EInteger subtrahend);

Subtracts an arbitrary-precision integer from this arbitrary-precision integer.

<b>Parameters:</b>

 * <i>subtrahend</i>: Another arbitrary-precision integer.

<b>Return Value:</b>

The difference of the two objects.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>subtrahend</i>
 is null.

### ToByteChecked

    public byte ToByteChecked();

Converts this number's value to a byte (from 0 to 255) if it can fit in a byte (from 0 to 255).

<b>Return Value:</b>

This number's value as a byte (from 0 to 255).

<b>Exceptions:</b>

 * System.OverflowException:
This value is less than 0 or greater than 255.

### ToBytes

    public byte[] ToBytes(
        bool littleEndian);

Returns a byte array of this integer's value. The byte array will take the number's two' s-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ), using the fewest bytes necessary to store its value unambiguously. If this value is negative, the bits that appear beyond the most significant bit of the number will be all ones. The resulting byte array can be passed to the  `FromBytes()`  method (with the same byte order) to reconstruct this integer's value.

<b>Parameters:</b>

 * <i>littleEndian</i>: If true, the byte order is little-endian, or least-significant-byte first. If false, the byte order is big-endian, or most-significant-byte first.

<b>Return Value:</b>

A byte array. If this value is 0, returns a byte array with the single element 0.

### ToByteUnchecked

    public byte ToByteUnchecked();

Converts this number to a byte (from 0 to 255), returning the least-significant bits of this number's two's-complement form.

<b>Return Value:</b>

This number, converted to a byte (from 0 to 255).

### ToInt16Checked

    public short ToInt16Checked();

Converts this number's value to a 16-bit signed integer if it can fit in a 16-bit signed integer.

<b>Return Value:</b>

This number's value as a 16-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This value is less than -32768 or greater than 32767.

### ToInt16Unchecked

    public short ToInt16Unchecked();

Converts this number to a 16-bit signed integer, returning the least-significant bits of this number's two's-complement form.

<b>Return Value:</b>

This number, converted to a 16-bit signed integer.

### ToInt32Checked

    public int ToInt32Checked();

Converts this object's value to a 32-bit signed integer, throwing an exception if it can't fit.

<b>Return Value:</b>

A 32-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 32-bit signed integer.

### ToInt32Unchecked

    public int ToInt32Unchecked();

Converts this object's value to a 32-bit signed integer. If the value can't fit in a 32-bit integer, returns the lower 32 bits of this object's two' s-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) (in which case the return value might have a different sign than this object's value).

<b>Return Value:</b>

A 32-bit signed integer.

### ToInt64Checked

    public long ToInt64Checked();

Converts this object's value to a 64-bit signed integer, throwing an exception if it can't fit.

<b>Return Value:</b>

A 64-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This object's value is too big to fit a 64-bit signed integer.

### ToInt64Unchecked

    public long ToInt64Unchecked();

Converts this object's value to a 64-bit signed integer. If the value can't fit in a 64-bit integer, returns the lower 64 bits of this object's two' s-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) (in which case the return value might have a different sign than this object's value).

<b>Return Value:</b>

A 64-bit signed integer.

### ToRadixString

    public string ToRadixString(
        int radix);

Generates a string representing the value of this object, in the given radix.

<b>Parameters:</b>

 * <i>radix</i>: A radix from 2 through 36. For example, to generate a hexadecimal (base-16) string, specify 16. To generate a decimal (base-10) string, specify 10.

<b>Return Value:</b>

A string representing the value of this object. If this value is 0, returns "0". If negative, the string will begin with a minus sign ("-", U+002D). Depending on the radix, the string will use the basic digits 0 to 9 (U+0030 to U+0039) and then the basic letters A to Z (U+0041 to U+005A). For example, 0-9 in radix 10, and 0-9, then A-F in radix 16.

<b>Exceptions:</b>

 * System.ArgumentException:
The parameter "index" is less than 0, "endIndex" is less than 0, or either is greater than the string's length, or "endIndex" is less than "index" ; or radix is less than 2 or greater than 36.

### ToSByteChecked

    public sbyte ToSByteChecked();

Converts this number's value to an 8-bit signed integer if it can fit in an 8-bit signed integer.

<b>Return Value:</b>

This number's value as an 8-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This value is less than -128 or greater than 127.

### ToSByteUnchecked

    public sbyte ToSByteUnchecked();

Converts this number to an 8-bit signed integer, returning the least-significant bits of this number's two's-complement form.

<b>Return Value:</b>

This number, converted to an 8-bit signed integer.

### ToString

    public override string ToString();

Converts this object to a text string in base 10.

<b>Return Value:</b>

A string representation of this object. If negative, the string will begin with a minus sign ("-", U+002D). The string will use the basic digits 0 to 9 (U+0030 to U+0039).

### ToUInt16Checked

    public ushort ToUInt16Checked();

Converts this number's value to a 16-bit unsigned integer if it can fit in a 16-bit unsigned integer.

<b>Return Value:</b>

This number's value as a 16-bit unsigned integer.

<b>Exceptions:</b>

 * System.OverflowException:
This value is less than 0 or greater than 65535.

### ToUInt16Unchecked

    public ushort ToUInt16Unchecked();

Converts this number to a 16-bit unsigned integer, returning the least-significant bits of this number's two's-complement form.

<b>Return Value:</b>

This number, converted to a 16-bit unsigned integer.

### ToUInt32Checked

    public uint ToUInt32Checked();

Converts this number's value to a 32-bit signed integer if it can fit in a 32-bit signed integer.

<b>Return Value:</b>

This number's value as a 32-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This value is less than 0 or greater than 4294967295.

### ToUInt32Unchecked

    public uint ToUInt32Unchecked();

Converts this number to a 32-bit signed integer, returning the least-significant bits of this number's two's-complement form.

<b>Return Value:</b>

This number, converted to a 32-bit signed integer.

### ToUInt64Checked

    public ulong ToUInt64Checked();

Converts this number's value to a 64-bit signed integer if it can fit in a 64-bit signed integer.

<b>Return Value:</b>

This number's value as a 64-bit signed integer.

<b>Exceptions:</b>

 * System.OverflowException:
This value is outside the range of a 64-bit signed integer.

### ToUInt64Unchecked

    public ulong ToUInt64Unchecked();

Converts this number to a 64-bit signed integer, returning the least-significant bits of this number's two' s-complement form.

<b>Return Value:</b>

This number, converted to a 64-bit signed integer.

### Xor

    public static PeterO.Numbers.EInteger Xor(
        PeterO.Numbers.EInteger a,
        PeterO.Numbers.EInteger b);

Finds the exclusive "or" of two arbitrary-precision integer objects.Each arbitrary-precision integer is treated as a two's-complement form (see[&#x22;Forms of numbers&#x22;](PeterO.Numbers.EDecimal.md) ) for the purposes of this operator.

<b>Parameters:</b>

 * <i>a</i>: The first arbitrary-precision integer.

 * <i>b</i>: The second arbitrary-precision integer.

<b>Return Value:</b>

An arbitrary-precision integer in which each bit is set if it's set in one input integer but not the other.

<b>Exceptions:</b>

 * System.ArgumentNullException:
The parameter <i>a</i>
 or  <i>b</i>
 is null.
