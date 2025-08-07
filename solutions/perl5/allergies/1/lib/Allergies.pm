package Allergies;

use v5.38;

use Exporter qw<import>;
our @EXPORT_OK = qw<allergic_to list_allergies>;

our @items = qw(eggs peanuts shellfish strawberries tomatoes
    chocolate pollen cats);
our %allergies = map { $items[$_] => 1<<$_ } 0..$#items;

sub allergic_to ( $item, $score ) {
    return $allergies{$item} & $score;
}

sub list_allergies ($score) {
    my @result = grep { $allergies{$_} & $score  } @items;
    return \@result;
}
