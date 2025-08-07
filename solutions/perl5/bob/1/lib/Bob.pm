# Declare package 'Bob'
package Bob;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<hey>;

sub hey ($msg) {
    if ($msg =~ /[A-Z].*\?\s*$/ && $msg eq uc $msg) {
        return "Calm down, I know what I'm doing!";
    } elsif ($msg =~ /\?\s*$/) {
        return "Sure.";
    } elsif ($msg =~ /[A-Z]/ && $msg eq uc $msg) {
        return "Whoa, chill out!";
    } elsif ($msg =~ /^\s*$/) {
        return "Fine. Be that way!";
    } else {
        return "Whatever.";
    }
}
