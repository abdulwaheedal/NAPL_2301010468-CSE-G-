package main

// Lab 4
import (
	"fmt"
	"time"
)

type Result struct {
	Task  string
	Value int
}

func square(n int, ch chan<- Result) {
	fmt.Println("Started: square")
	time.Sleep(300 * time.Millisecond)
	ch <- Result{"Square of 12", n * n}
	fmt.Println("Completed: square")
}

func cube(n int, ch chan<- Result) {
	fmt.Println("Started: cube")
	time.Sleep(100 * time.Millisecond)
	ch <- Result{"Cube of 5", n * n * n}
	fmt.Println("Completed: cube")
}

func fibonacci(n int, ch chan<- Result) {
	fmt.Println("Started: fibonacci")
	time.Sleep(200 * time.Millisecond)
	a, b := 0, 1
	for i := 0; i < n; i++ {
		a, b = b, a+b
	}
	ch <- Result{"Fibonacci(10)", a}
	fmt.Println("Completed: fibonacci")
}

func main() {
	results := make(chan Result, 3)

	go square(12, results)
	go cube(5, results)
	go fibonacci(10, results)

	for i := 0; i < 3; i++ {
		r := <-results
		fmt.Printf("Result: %s = %d\n", r.Task, r.Value)
	}

	fmt.Println("All tasks done")
}
