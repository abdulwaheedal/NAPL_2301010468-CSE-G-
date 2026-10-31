package main

import (
	"fmt"
	"math"
)

func divide(a, b float64) (float64, error) {
	if b == 0 {
		return 0, fmt.Errorf("cannot divide %v by zero", a)
	}
	return a / b, nil
}

func squareRoot(n float64) (float64, error) {
	if n < 0 {
		return 0, fmt.Errorf("cannot take square root of negative number %v", n)
	}
	return math.Sqrt(n), nil
}

func average(nums []float64) (float64, error) {
	if len(nums) == 0 {
		return 0, fmt.Errorf("cannot find average of an empty list")
	}
	total := 0.0
	for _, n := range nums {
		total += n
	}
	return total / float64(len(nums)), nil
}

func main() {
	if r, err := divide(10, 2); err != nil {
		fmt.Println("error:", err)
	} else {
		fmt.Println("10 / 2 =", r)
	}

	if _, err := divide(7, 0); err != nil {
		fmt.Println("error:", err)
	}

	if _, err := squareRoot(-9); err != nil {
		fmt.Println("error:", err)
	}

	if _, err := average([]float64{}); err != nil {
		fmt.Println("error:", err)
	}
}
