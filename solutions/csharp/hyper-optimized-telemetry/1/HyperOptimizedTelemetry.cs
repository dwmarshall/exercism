public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = Enumerable.Repeat((byte)0, 9).ToArray();
        if (reading >= 4_294_967_296) {
            buffer[0] = 256 - 8;
            BitConverter.GetBytes(reading).CopyTo(buffer, 1);
        } else if (reading >= 2_147_483_648) {
            buffer[0] = 4;
            BitConverter.GetBytes((uint)reading).CopyTo(buffer, 1);
        } else if (reading >= 65_536) {
            buffer[0] = 256 - 4;
            BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
        } else if (reading >= 0) {
            buffer[0] = 2;
            BitConverter.GetBytes((ushort)reading).CopyTo(buffer, 1);
        } else if (reading >= -32_768) {
            buffer[0] = 256 - 2;
            BitConverter.GetBytes((short)reading).CopyTo(buffer, 1);
        } else if (reading >= -2_147_483_648) {
            buffer[0] = 256 - 4;
            BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
        } else {
            buffer[0] = 256 - 8;
            BitConverter.GetBytes(reading).CopyTo(buffer, 1);
        }
        return buffer;
    }
    public static long FromBuffer(byte[] buffer)
    {
        if (buffer[0] == 2) {
            return (long)BitConverter.ToUInt16(buffer[1 .. 3]);
        } else if (buffer[0] == 4) {
            return (long)BitConverter.ToUInt32(buffer[1 .. 5]);
        } else if (buffer[0] == 8) {
            return (long)BitConverter.ToUInt64(buffer[1 .. 9]);
        } else if (buffer[0] == 254) {
            return (long)BitConverter.ToInt16(buffer[1 .. 3]);
        } else if (buffer[0] == 252) {
            return (long)BitConverter.ToInt32(buffer[1 .. 5]);
        } else if (buffer[0] == 248) {
            return (long)BitConverter.ToInt64(buffer[1 .. 9]);
        } else {
            return 0L;
        }
    }
}
