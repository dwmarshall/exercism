package Clock;

use v5.38;
use Moo;

# rwp = read-write protected
has hour   => (
    is => 'rwp',
);
has minute => (
    is => 'rwp',
);

around 'new' => sub {
    my $orig = shift;
    my $self = shift;

    my %args = @_;
    my $hour = $args{hour};
    my $minute = $args{minute};
    while ($minute >= 60) {
        $hour++;
        $minute -= 60;
    }
    while ($minute < 0) {
        $hour--;
        $minute += 60;
    }
    $hour += 24 while $hour < 0;
    $hour %= 24;

    $orig->($self, hour => $hour, minute => $minute);
};

sub time ($self) {
    my $hour = $self->hour;
    my $minute = $self->minute;
    while ($minute >= 60) {
        $hour++;
        $minute -= 60;
    }
    while ($minute < 0) {
        $hour--;
        $minute += 60;
    }
    return sprintf "%02d:%02d", $hour % 24, $minute;
}

sub add_minutes ( $self, $amount ) {
    my $hour = $self->hour;
    my $minute = $self->minute;
    $minute += $amount;
    while ($minute >= 60) {
        $hour++;
        $minute -= 60;
    }
    $hour %= 24;
    $self->_set_hour($hour);
    $self->_set_minute($minute);
    return $self;
}

sub subtract_minutes ( $self, $amount ) {
    my $hour = $self->hour;
    my $minute = $self->minute;
    $minute -= $amount;
    while ($minute < 0) {
        $hour--;
        $minute += 60;
    }
    $self->_set_hour($hour);
    $self->_set_minute($minute);
    return $self;
}
