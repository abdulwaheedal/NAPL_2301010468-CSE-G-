package main

import "testing"

func TestDivideValid(t *testing.T) {
	got, err := divide(10, 4)
	if err != nil {
		t.Fatalf("unexpected error: %v", err)
	}
	if got != 2.5 {
		t.Errorf("divide(10, 4) = %v, want 2.5", got)
	}
}

func TestDivideByZero(t *testing.T) {
	_, err := divide(5, 0)
	if err == nil {
		t.Fatal("expected an error for division by zero, got nil")
	}
	want := "cannot divide 5 by zero"
	if err.Error() != want {
		t.Errorf("got %q, want %q", err.Error(), want)
	}
}

func TestSquareRootValid(t *testing.T) {
	got, err := squareRoot(16)
	if err != nil {
		t.Fatalf("unexpected error: %v", err)
	}
	if got != 4 {
		t.Errorf("squareRoot(16) = %v, want 4", got)
	}
}

func TestSquareRootNegative(t *testing.T) {
	_, err := squareRoot(-4)
	if err == nil {
		t.Fatal("expected an error for negative input, got nil")
	}
}

func TestAverageValid(t *testing.T) {
	got, err := average([]float64{2, 4, 6})
	if err != nil {
		t.Fatalf("unexpected error: %v", err)
	}
	if got != 4 {
		t.Errorf("average = %v, want 4", got)
	}
}

func TestAverageEmpty(t *testing.T) {
	_, err := average(nil)
	if err == nil {
		t.Fatal("expected an error for empty input, got nil")
	}
}
