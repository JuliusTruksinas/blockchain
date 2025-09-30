# The idea behind the custom hash function

1. because we need to generate a 256 bit hash, we can start with 4 random 64 bit seed numbers(ulong in c#) because 64 bits x 4 = 256 bits
2. we take the input text and for each input byte, we perform add/xor/rotate operations, and cross-mix with the other seed numbers.
3. at the end when the original 4 seed number are all mixed with the input bytes we format each 64-bit seed number as 16 hex chars and concatenate to 64-char uppercase hex string.

# Instructions to generate test data

You can generate test data using the CLI arguments:

1. make sure you are in the Hash project folder.
2. use the following command `dotnet run testData <folder_path>`, here `<folder_path>` is the folder path where the test data will be created.

# Tests

## Test that the hash function output size always stays the same regardless of the input size

### Custom hash function

![alt text](image.png)

empty file -> `DC6D0C402D9C247F802FB614C5C8C1EB86DE0F8C2EB03CB2692A7F08CAEFAF33`
file with 2000 random characters -> `947C177DCAB2D235BCB457A8DF6F227AC2341DDE78D3230BF7AD5BADB0B8EF53`
file with 100,000 pairs of strings with length 10 -> `803DEFAA1C0919EB197BF76CB5B81B20C8B68E5B694DDAF15BF2AB5A5B0F5613`

**Conclusion:** in every case the output size was the same - 64 hex characters

### AI generated hash function

![alt text](image-2.png)

empty file -> `EFD01F60BA9929266BCB9D63EB8EAB8B83D8725B90D9D7E1765BA009AE97681A`
file with 2000 random characters -> `2DD33AA39BCF5C21AF2338CA0E6E106C7F4D48467F37359C1210BB394A9FDB6E`
file with 100,000 pairs of strings with length 10 -> `25CD3FA7AD1EEF3421EA4D3D18064B379A12CAC304A8AA189A7D79EB17F6D732`

**Conclusion:** in every case the output size was the same - 64 hex characters

## Test that the hash function is deterministic

### Custom hash function

![alt text](image-1.png)
**Conclusion:** as you can see from the image provided above, if you run the program with the same input data you always get the same output.

### AI generated hash function

![alt text](image-3.png)
**Conclusion:** as you can see from the image provided above, if you run the program with the same input data you always get the same output.
