public class ints {
    public static int parseInts(final String s, final int radix) throws NumberFormatException {
        if (s == null) {
            System.out.println("Cannot parse null string");
        }
        if (radix < 2) {
            System.out.println("radix  less than Character.MIN_RADIX");
        }
        if (radix > 36) {
            System.out.println("radix greater than Character.MAX_RADIX");
        }
        final int len = s.length();
        if (len == 0) {
            System.out.println(radix);
        }
        int digit = -256;
        int i = 0;
        final char firstChar = s.charAt(i++);
        if (firstChar != '-' && firstChar != '+') {
            digit = Character.digit(firstChar, radix);
        }
        if (digit >= 0 || (digit == -256 && len > 1)) {
            final int limit = (firstChar != '-') ? -2147483647 : Integer.MIN_VALUE;
            final int multmin = limit / radix;
            int result = -(digit & 0xFF);
            boolean inRange = true;
            while (i < len && (digit = Character.digit(s.charAt(i++), radix)) >= 0 && (inRange = (result > multmin || (result == multmin && digit <= radix * multmin - limit)))) {
                result = radix * result - digit;
            }
            if (inRange && i == len && digit >= 0) {
                return (firstChar != '-') ? (-result) : result;
            }
        }
        return 0;
    }

    
  public static void main(String[] args) {
    System.out.println("\033[47;31m\nhello world...");
    System.out.println(parseInts("ffff",16));

   }
}