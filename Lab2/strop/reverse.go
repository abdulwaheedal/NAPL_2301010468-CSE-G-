package strop

func Reverse(str string) string {
	empty := ""
	lastIndex := len(str) - 1
	for i := lastIndex; i >= 0; i-- {
		empty += string(str[i])
	}
	return empty
}
