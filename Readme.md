## Task 1

You have to write a JavaScript code that prints the longest common substring of passed arguments (with trailing newline — just use console.log for output).
- The code will be running under Node.js and arguments will be passed via command line (you should not read standard input stream).
- If the longest common superstring is empty (no arguments are passed or arguments have no common substrings) it’s necessary to print single newline.
- If there are several solution print any single one of them.
- Limits: single string length is less or equal to 256, number of strings is less or equal to 64, strings contain only English letter and digits, time limit per test is 5 seconds.
- The output should not contain any excess characters.
- The solution is accepted if all tests are passed. The result is calculated based on JavaScript file size (the smaller the better). So, no comments, no long names, no indents, etc.
- You cannot use any external packages (there is only clean Node.js installation on the server).
- You have to use only command-line arguments (no readline, no process.stdin, etc.; ONLY process.argv).
- When called without arguments, your script should not fail.

## Task 2

Language: JavaScript or TypeScript or Java or C# or anything you like.
Calculate SHA3-256 for every file from archive (https://www.dropbox.com/s/oy2668zp1lsuseh/task2.zip?dl=1). Note, files are binary, you don’t need encodings — if you read file to string with some encoding, you have to use the same encoding to decode string into bytes for hashing (there is a technical term for such conversions “stupid activity”).

- Write hashes as 64 hex digits in lower case.
- Sort hashes as strings.
- Join sorted hashes without any separator.
- Concatenate resulted string with your e-mail.
- Find the SHA3-256 of the result string.
- Send obtained 64 hex digits in the lower case to ilearning.task2@gmail.com.
- Note: SHA3-256 is not the same algorithm as SHA-256. 
