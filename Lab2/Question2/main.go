package main

import (
	"fmt"
	"slices"
)

func main() {
	// Appending
	ages := []int{2, 4, 5}

	fmt.Println(ages)
	var a int

	fmt.Println("Enter a number to add to the slice: ")
	fmt.Scan(&a)

	ages = append(ages, a)
	fmt.Println(ages)

	// Remove By Index
	var b int
	fmt.Println("Enter the index you want to remove: ")
	fmt.Scan(&b)
	ages = slices.Delete(ages, b, b+1)
	fmt.Println(ages)

	// Update operations
	var c int
	fmt.Println("Which Index you want to update: ")
	fmt.Scan(&c)
	
	ages[c] = 7
	fmt.Println(ages)

	// Maps
	subject := map[string]int{}
	subject["Mathematics"] = 80
	subject["Social Sciences"] = 90
	subject["Geography"] = 95
	subject["Computer Science"] = 79

	fmt.Println(subject)

	delete(subject, "Geography")
	fmt.Println(subject)

	fmt.Println(subject["Computer Science"])
	fmt.Println(subject)

}
