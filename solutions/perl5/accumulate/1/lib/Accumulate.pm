package Accumulate;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<accumulate>;

sub accumulate ( $list, $func ) {
    my @result;
    foreach (@$list) {
        push @result, $func->($_);
    }
    return \@result;
}
