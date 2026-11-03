// stringProcessing.fsx  --  run with: dotnet fsi stringProcessing.fsx
open System
open System.Text.RegularExpressions
open System.Numerics

// ---------- Small test helpers ----------
let show (x: 'a) = sprintf "%A" x

let runTests title (f: string -> 'a) (cases: (string * 'a) list) =
    printfn "\n=== %s ===" title
    cases
    |> List.iter (fun (input, expected) ->
        let actual = f input
        let status = if actual = expected then "PASS" else "FAIL"
        printfn "%-40s -> %-28s [%s]" (show input) (show actual) status)

// ---------- Task 1: reverse + palindrome ----------
let reverseString (s: string) =
    s |> Seq.rev |> Seq.map string |> String.concat ""

// Palindrome check ignores case, spaces and punctuation.
// Empty / symbol-only input is NOT treated as a palindrome.
let normalise (s: string) =
    s
    |> Seq.filter (fun c -> Char.IsLetterOrDigit c)
    |> Seq.map (fun c -> string (Char.ToLower c))
    |> String.concat ""

let isPalindrome (s: string) =
    let n = normalise s
    n <> "" && n = reverseString n

let reverseAndCheck s = reverseString s, isPalindrome s

// ---------- Task 2: transform using an active pattern ----------
let (|AllLetters|AllDigits|Mixed|) (s: string) =
    if s <> "" && s |> Seq.forall (fun c -> Char.IsLetter c) then AllLetters
    elif s <> "" && s |> Seq.forall (fun c -> c >= '0' && c <= '9') then AllDigits
    else Mixed

let transform (s: string) =
    match s with
    | AllLetters -> s.ToUpper()
    // "double" is read as: numeric value x 2 (BigInteger avoids overflow)
    // For string doubling ("123" -> "123123") use: s + s
    | AllDigits -> (BigInteger.Parse s * 2I).ToString()
    | Mixed -> s

// ---------- Task 3: email validation (Regex + pattern matching) ----------
let emailPattern =
    @"^[A-Za-z0-9_%+-]+(\.[A-Za-z0-9_%+-]+)*@([A-Za-z0-9]([A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z]{2,}\z"

let (|ValidEmail|InvalidEmail|) (s: string) =
    if not (String.IsNullOrWhiteSpace s) && Regex.IsMatch(s, emailPattern)
    then ValidEmail
    else InvalidEmail

let isValidEmail s =
    match s with
    | ValidEmail -> true
    | InvalidEmail -> false

// ---------- Test data (>= 3 inputs per task) ----------
let palindromeTests =
    [ "racecar", ("racecar", true)
      "Level", ("leveL", true)
      "12321", ("12321", true)
      "A man, a plan, a canal: Panama", ("amanaP :lanac a ,nalp a ,nam A", true)
      "hello", ("olleh", false) ]

let transformTests =
    [ "hello", "HELLO"
      "World", "WORLD"
      "12345", "24690"
      "007", "14"
      "abc123", "abc123"
      "hello world", "hello world"
      "", "" ]

let emailTests =
    [ "user@example.com", true
      "first.last+tag@sub.domain.org", true
      "a_b@x-y.co", true
      "plainaddress", false
      "@no-local.com", false
      "a..b@example.com", false
      "user@domain", false
      "user@.com", false
      "user name@example.com", false ]

runTests "Task 1: reverse + palindrome" reverseAndCheck palindromeTests
runTests "Task 2: transform" transform transformTests
runTests "Task 3: email validation" isValidEmail emailTests
