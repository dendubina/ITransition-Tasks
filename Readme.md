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

## Task 4

Use you language and platform: JavaScript/TypeScript+React+Node.js+Express+ MySQL or .NET/Core+C#+ASP.NET+SQL Server. Create a Web application with registration and authentication.

- Non-authenticated users should not have access to the user management (admin panel).
- Authenticated users should have access the user management table: id, name, e-mail, last login time, registration time, status (active/blocked).
- The left column of the table should contains checkboxes without labels for multiple selection (table header contains “Select All” checkbox without label).
- There must be a toolbar over the table with the flooring actions: Block (red button with text), Unblock (icon), Delete (icon).
- You have to use a CSS framework (Bootstrap is recommended, but you can choose any CSS framework).
- Every users should be able to block or delete yourself or any other user.
- If user account is blocked or deleted any next user’s request should redirect to the login page.
- User can use any non-empty password (even one character).
- Blocked user should not be able to login, deleted user can re-register.

#### How to submit the solution:

Send to p.lebedev@itransition.com:
- Full name.
- Link to the deployed project (you can use any hosting you find suitable).
- Recorded video:  registration, login, non-current user selection, user blocking (the user status should be updated), user unblocking, all user selection (including current), all user blocking (with automatic redirection to the login page). 

