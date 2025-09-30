# The idea behind the custom hash function

1. because we need to generate a 256 bit hash, we can start with 4 random 64 bit seed numbers(ulong in c#) because 64 bits x 4 = 256 bits
2. we take the input text and for each input byte, we perform add/xor/rotate operations, and cross-mix with the other seed numbers.
3. at the end when the original 4 seed number are all mixed with the input bytes we format each 64-bit seed number as 16 hex chars and concatenate to 64-char uppercase hex string.

# Instructions to generate test data

You can generate test data using the CLI arguments:

1. make sure you are in the Hash project folder.
2. use the following command `dotnet run testData <folder_path>`, here `<folder_path>` is the folder path where the test data will be created.
