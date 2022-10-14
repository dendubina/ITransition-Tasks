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

## Task 5

Stack is the same as in #4.

- Create a Web application without registration and authentication. 
- At the start user have to enter its name (just name without password or anything).
- After entering its name user get to the “send a message” form: recipient, title and the message body.
- Recipient field should support autocompletion — when the user starts entering name, dropdown is shown with the corresponding names (you have to use ready component for this).
- Body field  is multiline text (textarea).
- You have to use a CSS framework (Bootstrap is recommended, but you can choose any CSS framework).
- Under “send a message” you have to display all messages send to the current user.
- The application is akin to an e-mail application, not a chat.
- All messages are stored in database forever. So, if somebody uses the same name, they will see all corresponding messages.
- You can either implement auto-refresh every 5 seconds to catch new messages for the current user or — it’s better, but optional — use websockets to push new messages to the user.
- Users can send message to themselves — so, do not write additional branch to remove current user from autocompletion, etc.

## Task 6

Implement a Web-application for the fake (random) user data generation.

The single app page allows to:
1) select region (at least 3 different, e.g. Poland, USA, Georgia or anything you prefer)
2) specify the number of error per record (slider 0..10 + binded number field with max value limit at least 1000)
3) define seed value and [Random] button to generate a random seed

- If the user change anything, the table below (20 records are generated again).

- It's necessary to support infinite scrolling in the table (you show 20 records and if the user scroll down, you add next 10 record below).

The table show contain the following fields:
1) Index (1, 2, 3, ...)
2) Random identifier
3) Name + middle name + last name (in region format)
4) Address (in several possible formats, e.g. city+street+building+appartment or county+city+street+house)
5) Phone (again, it's great to have several formats, e.g. international or local ones)

- Language of the names and address as well as phone codes or zip codes should be correleted to region. You need to generate random data that looks somehow realistically. So, in Poland — Polish, in USA - English or Spanish, etc.
What is error? It's data entry error emulation. The end user specify number of errors PER RECORD. If errors = 0, there are no errors in user data. If error = 0.5, every record contains an error with probability 0.5 (one error per two recods). 10 errors results in 10 errors in every record. Error number can be entered with a slider or field (they interconnected, if change one control, other is changed too).

- You need to support 3 type of errors - delete character in random position, add random character (from a proper alphabet) in random position, swap near characters. Type of the error have to be chosen ramdomly with equal probabilities (when user specifies 1000 errors, "noisy user data" should not be too long or too short).
About seed.

- Of course, you do not store RANDOM data on the server. When the user change seed, you have to change generated data. It's important that the seed passed to RNG algorithm is combination of the user seed and page number (so, you do not re-generate pages 1..9 when the user requests page 10). How to combine - it's not really important, some kind of sum should be enough. IMPORTANT: if I enter the same seed tomorrow I have to get the same data as today (even errors) on all pages - it's especially important for optional requirement.

- Of course, you will need to user lookup tables with names and surnames (separately, to be able to combine) as well as cities, etc.. They have to be large enough (more than 2 names and 10 surnames), let's say hundreds of names and several thousands of surnames. Your goal - approximately — avoid full user data duplication in ~10_000_000 records.

And again: data should look like realistic. 
