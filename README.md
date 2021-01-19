# PokerHandSorter

## Description
PokerHandSorter is a command line program that takes, via STDIN, a "stream" of hands for a two player poker game. At the completion of the stream, the program would print to STDOUT the number of hands won by Player 1, and the number of hands won by Player 2.
Further description can be found in Documents/poker-exercise.pdf

## Running the sample
To run the sample with the sample file provided

1. Open the solution and build it
2. Open a PowerShell prompt from the bin folder (i.e solutionfolder\PokerHandSorter\bin\Debug\netcoreapp3.1)
3. In the PowerShell prompt, type these and press return. `Get-Content ..\..\..\Samples\poker-hands.txt |  .\PokerHandSorter.exe`
