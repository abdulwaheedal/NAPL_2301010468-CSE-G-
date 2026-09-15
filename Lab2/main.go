package main

import (
	"fmt"
	"lab2/mathutil"
	"lab2/strop"
)

func main() {
	fact := mathutil.Factorial(5)
	fmt.Printf("Factorial: %d\n", fact);

	pow := mathutil.Power(2, 3)
	fmt.Printf("Power: %d\n", pow)

	rev := strop.Reverse("ziaaF")
	fmt.Printf("Reverse: %s\n", rev)

	count := strop.Count("Abdul Waheed Al Faaiz")
	fmt.Printf("Count: %d\n",count)
}
