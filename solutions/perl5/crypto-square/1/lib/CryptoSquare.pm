package CryptoSquare;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<cipher>;

sub cipher ($text) {
    my $original = $text;
    $text = lc $text;
    $text =~ s/[^a-z0-9]//g;

    my $c = int(sqrt(length($text)));
    my $r = $c;
    $c++ if $c * $r < length($text);
    $r++ if $c * $r < length($text);
    $text .= ' ' while length($text) < $c * $r;

    my @pieces;

    for (my $column = 0; $column < $c; $column++) {
        my $piece;
        for (my $row = 0; $row < $r; $row++) {
            $piece .= substr($text, $row * $c + $column, 1);
        }
        push @pieces, $piece;

    }
    my $output = join ' ' => @pieces;
    return $output;
}
