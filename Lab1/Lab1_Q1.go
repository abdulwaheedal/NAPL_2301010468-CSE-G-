package main

import "fmt"

func main() {
	var int1 = 4 
	var int2 = 8
	var float1 = 8.7
	var float2 = 9.3

	fmt.Println("Hello! Faaiz")
	
	fmt.Println("Integer Operations")
	fmt.Printf("Subtraction = %d\n", int1 - int2)
	fmt.Printf("Addition = %d\n", int1 + int2)
	fmt.Printf("Division = %d\n", int1 / int2)
	fmt.Printf("Multiplication = %d\n", int1 * int2)

	fmt.Println("Float Operations")
	fmt.Printf("Subtraction = %f\n", float1 - float2)
	fmt.Printf("Addition = %f\n", float1 + float2)
	fmt.Printf("Division = %f\n", float1 / float2)
	fmt.Printf("Multiplication = %v\n", float1 * float2)
}
