# RandomFriendlyNameGenerator
Simple but flexible and powerful utility for generating random names and identifiers - with configurable number of components, separators, length and structure, usable in a single line of code.

# Examples

## Human names
Get a simple random name:  
```csharp
string name = NameGenerator.PersonNames.Get();
```  
returns a single random name & surname, similar to below:
- Jeana Chalow
- Jaine Bobson
- Godfrey Manning
- Brian Deperro
- Owen Tatem

For any method you can specify additional settings and parameters, e.g:  
```csharp
IEnumerable<string> names = NameGenerator.PersonNames.Get(5, NameGender.Male, NameComponents.FirstNameMiddleNameLastName);
```  
returns:  
- Byron Lorenzo Haan
- Timmy Evan Swimm
- Thorn Vinnie Abbott
- Darin Demetris Kurshuk
- Godfry Connor Howlin

or  
```csharp
IEnumerable<string> names = NameGenerator.PersonNames.Get(5, NameGender.Female, NameComponents.LastNameFirstName, separator: ", ");
```  
which returns:  
- Hebner, Rafaela
- Bloss, Suzanna
- Parkinson, Carline
- Smid, Dottie
- Boegel, Jacklin




