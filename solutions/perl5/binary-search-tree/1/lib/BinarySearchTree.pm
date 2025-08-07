package BinarySearchTree;

use v5.38;
use Moo;

package BinarySearchTree::Node {
    use Moo;

    has data => (
        is => 'ro',
    );
    has [qw<left right>] => (
        is => 'rw',
    );
};

has root => (
    is => 'rw',
);

sub add ($self, $value) {
    my $new_node = BinarySearchTree::Node->new( data => $value);
    my $working_node = $self->root;
    while (1) {
        if ($value <= $working_node->data) {
            if (defined $working_node->left) {
                $working_node = $working_node->left;
            } else {
                $working_node->left($new_node);
                last;
            }
        } else {
            if (defined $working_node->right) {
                $working_node = $working_node->right;
            } else {
                $working_node->right($new_node);
                last;
            }
        }

    }
    # $self->root contains the initial node.
}

sub sort ($self) {
    use Data::Dumper;
    my @results;
    my @stack;
    my $current_node = $self->root;
    while (@stack || $current_node) {
        if (defined $current_node) {
            push @stack, $current_node;
            $current_node = $current_node->left;
        } else {
            $current_node = pop @stack;
            push @results, $current_node->data;
            $current_node = $current_node->right;
        }
    }
    return \@results;
}
