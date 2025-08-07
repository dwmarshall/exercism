package InventoryManagement;

use v5.38;

sub create_inventory ($items) {
    my %inventory;
    foreach (@$items) {
        $inventory{$_}++;
    }
    return \%inventory;
}

sub add_items ( $inventory, $items ) {
    foreach (@$items) {
        $inventory->{$_}++;
    }
    return $inventory;
}

sub remove_items ( $inventory, $items ) {
    foreach (@$items) {
        next unless $inventory->{$_} > 0;
        $inventory->{$_}--;
    }
    return $inventory;
}

sub delete_item ( $inventory, $item ) {
    delete $inventory->{$item};
    return $inventory;
}
