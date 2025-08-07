package AtbashCipher;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<encode_atbash decode_atbash>;

sub encode_atbash ($phrase) {
    # remove the spaces
    $phrase =~ s/[^a-zA-Z0-9]//g;
    # split the string
    my @letters = split //, lc $phrase;
    foreach (@letters) {
        my $ord = ord($_);
        if ($ord >= 97 && $ord <= 122) {
            $_ = chr(ord('a') + ord('z') - $ord)
        }
    }
    my @pieces;
    while (@letters) {
        push @pieces, join '' => splice(@letters, 0, 5);
    }
    join ' ' => @pieces;

}

sub decode_atbash ($phrase) {
    # remove the spaces
    $phrase =~ s/\s//g;
    my @letters = split //, $phrase;
    foreach (@letters) {
        if (ord($_) >= 97 && ord($_) <= 122) {
            $_ = chr(ord('a') + ord('z') - ord($_))
        }
    }
    return join '' => @letters;
}
