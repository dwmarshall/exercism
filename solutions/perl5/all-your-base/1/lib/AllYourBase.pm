package AllYourBase;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<rebase>;

my @errors = (
    'input base must be >= 2',
    'output base must be >= 2',
    'all digits must satisfy 0 <= d < input base',
);

sub rebase ( $digits, $input_base, $output_base ) {
    my $number = 0;
    die $errors[0] if $input_base < 2;
    die $errors[1] if $output_base < 2;
    foreach my $digit (@$digits) {
        if ($digit < 0 || $digit >= $input_base) {
            die $errors[2];
        }
        $number *= $input_base;
        $number += $digit;
    }
    if ($number == 0) {
        return [0];
    }
    my @output;
    while ($number) {
        unshift @output, ($number % $output_base);
        $number = int($number / $output_base);
    }
    return \@output;
}
