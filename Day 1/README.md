# Day 1: C

The challenge for day one started out pretty simple: using two lists of numbers (provided to you in a tab separated text file), sort both lists and return a sum with the distance between each indexed pair. The second half of day one's challenge wants a similarity score utilizing the lists (see challenge details here: https://adventofcode.com/2024/day/1). This seems relatively straightforward, so naturally I chose to build it with C - a language I had zero experience in.

Simple things like getting the total number of lines in a text file is a trip back to Programming 101 and makes me appreciate how built out modern languages are. It's also humbling to revisit the process of designing sorting algorithms from scratch, though I'm relieved a professor is not grading me on the runtime complexity for this!

Although I landed on the right answer, there are opportunities to split out my main function into more simple reusable components... something I don't have much time for today unfortunately, but will revisit in the future.