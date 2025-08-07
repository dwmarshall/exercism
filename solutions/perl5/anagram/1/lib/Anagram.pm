package Anagram;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<match_anagrams>;

sub match_anagrams ( $subject, $candidates ) {
    my $sorted_subject = join '' => sort split //, lc $subject;
    my @result;
    foreach my $word (@$candidates) {
        next if lc $subject eq lc $word;
        my $sorted_word = join '' => sort split //, lc $word;
        push @result, $word if $sorted_subject eq $sorted_word;
    }
    \@result;
}
