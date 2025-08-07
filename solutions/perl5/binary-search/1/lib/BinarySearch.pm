package BinarySearch;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<binary_search>;

sub binary_search ( $array, $value ) {
    die 'value not in array' if (@$array == 0 || $value < $array->[0] || $value > $array->[-1]);
    my $start_index = 0;
    my $end_index = $#$array;
    my $middle_index = int(($end_index - $start_index) / 2);
    while ($end_index >= $start_index) {
        $middle_index = $start_index + int(($end_index - $start_index) / 2);
        return $middle_index if $array->[$middle_index] == $value;
        if ($array->[$middle_index] > $value) {
            $end_index = $middle_index - 1;
        } else {
            $start_index = $middle_index + 1;
        }
    }
    return $start_index if ($start_index == $end_index && $array->[$start_index] == $value);
    die 'value not in array';
}
