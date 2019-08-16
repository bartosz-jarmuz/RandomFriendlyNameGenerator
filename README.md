# RandomFriendlyNameGenerator [![Build status](https://bartosz-jarmuz.visualstudio.com/RandomFriendlyNameGenerator/_apis/build/status/RandomFriendlyNameGenerator-.NET%20Desktop-CI)](https://bartosz-jarmuz.visualstudio.com/RandomFriendlyNameGenerator/_build/latest?definitionId=21)
Simple but flexible and powerful utility for generating random names and identifiers - with configurable number of components, separators, length and structure, usable in a single line of code.

> **Get it from NuGet: https://www.nuget.org/packages/RandomFriendlyNameGenerator**  

> **Try it out:  
> https://namegenerator.azurewebsites.net/api/GetName  
> https://namegenerator.azurewebsites.net/api/GetNames/10 (if you want to get 10 names)    
> *or with more params*    
> https://namegenerator.azurewebsites.net/api/GetNames/10?template=BobTheBuilder&orderStyle=BobTheBuilderStyle&separator=-**  

*\*This is not guaranteed service, i.e. this AzureFunction might get disabled without notice*

# Examples
In all methods you can specify the separator, the length restriction and whether generated words should all start with a single character (i.e. alliteration).  
Also, each method has an overload which returns an IEnumerable instead of a single string.

## Human names
Get a simple random human-like name:  
```csharp
string name = NameGenerator.PersonNames.Get();
```  
returns a single random name & surname, similar to below:
- Jeana Chalow
- Jaine Bobson
- Godfrey Manning

For any method you can specify additional settings and parameters related to the name format, e.g:  
```csharp
IEnumerable<string> names = NameGenerator.PersonNames.Get(5, NameGender.Male, NameComponents.FirstNameMiddleNameLastName);
```  
returns:  
- Byron Lorenzo Haan
- Timmy Evan Swimm
- Darin Demetris Kurshuk

or  
```csharp
var names = NameGenerator.PersonNames.Get(5, NameGender.Female, NameComponents.LastNameFirstName, separator: ", ");
```  
which returns:  
- Bloss, Suzanna
- Parkinson, Carline
- Boegel, Jacklin

## Other identifiers
Get a simple random identifier:  
```csharp
string name = NameGenerator.Identifiers.Get();
```  
returns a single random adjective & noun, similar to below:
- Adrenalized Soup
- Informed Confusion (yup, *that* got generated)
- Unpromising Graduation

For any method you can specify additional settings and parameters, to control the output e.g:  
```csharp
var names =  NameGenerator.Identifiers.Get(5, IdentifierComponents.FirstName | IdentifierComponents.Animal);
```  
returns:  
- SavannaBaboon Zollie
- Mastodon Rubi
- Rooster Hewet

or take more components and set the name to be first (a.k.a Bob The Builder style) 
```csharp
NameGenerator.Identifiers.Get(15, IdentifierComponents.FirstName | IdentifierComponents.Adjective | IdentifierComponents.Animal, NameOrderingStyle.BobTheBuilderStyle);
```  
which returns:  
- Morton The Unfriendly Crocodile
- Ki The Skilled Cuckoo
- Dacey The Illicit Labradoodle

or do something similar to Docker containers names, but with a very short strings
```csharp
NameGenerator.Identifiers.Get(15, IdentifierComponents.Adjective | IdentifierComponents.Noun, separator: "_", lengthRestriction: 10);
```  
which returns:  
- Spare_Host
- Human_Vase
- Mad_Clue
- Cocky_Bait
 
or you can go wild with picking any two random components and force them all to be alliterated
```csharp
NameGenerator.Identifiers.Get(15,IdentifierTemplate.AnyTwoComponents, separator: "", forceSingleLetter: true);
```  
which returns:  
- BelgianBen
- KitchenKorella
- FinancialFerret
- CameroonianChane
- FilipinoFinisher
- NonexclusiveNoodle
- FleetingFrank
- ElectricityEwan
- InscrutableInstructor

or use one of the predefined templates, e.g.
```csharp
NameGenerator.Identifiers.Get(5, IdentifierTemplate.BobTheBuilder);
NameGenerator.Identifiers.Get(5, IdentifierTemplate.SilentBob);
NameGenerator.Identifiers.Get(5, IdentifierTemplate.GitHub);
```  
etc.

# Uniqueness and possible combinations

*(The latest values for the info below are available in the 'Showcase' class in the tests project)*

At the moment the lists of words contain the following numbers: 

- **Adjectives**: 4841
- **Nationalities**: 186
- **FemaleFirstNames**: 5047
- **MaleFirstNames**: 3025
- **LastNames**: 88799
- **Animals**: 1160
- **Nouns**: 5916
- **Professions**: 411
Total of 109385 words. Unique words: 104049

Which in total allows for quite a few combinations:

- **Possible first name and last names combinations**: 716 785 528
- **Possible first name, middle name and last names combinations**: 571 834 304
- **Possible first name and adjective combinations**: 78 153 104
- **Possible first name and animal combinations**: 9 363 520
- **Possible first name and profession combinations**: 3 317 592
- **Possible first name, adjective and animal combinations**: 463 287 424
- **Possible first name, adjective and profession combinations**: 2 056 154 672

# Performance

*(The latest values for the info below are available in the 'UniquenessTests' class in the tests project)*

Code below, executed in loops of 100 000 and 1 000 000 times yields following results *(they include overhead of adding strings to list)*
```csharp
 NameGenerator.Identifiers.Get(IdentifierTemplate.AnyThreeComponents,  NameOrderingStyle.BobTheBuilderStyle)
 ```

> Generated 100 000. Duplicates: 1. Duplicates percentage: 0.00100. Elapsed: 329ms   
> Generated 100 000. Duplicates: 0. Duplicates percentage: 0. Elapsed: 408ms   
> Generated 100 000. Duplicates: 1. Duplicates percentage: 0.00100. Elapsed: 374ms   

> Generated 1 000 000. Duplicates: 51. Duplicates percentage: 0.005100. Elapsed: 3440ms   
> Generated 1 000 000. Duplicates: 49. Duplicates percentage: 0.004900. Elapsed: 3138ms   
> Generated 1 000 000. Duplicates: 33. Duplicates percentage: 0.003300. Elapsed: 3362ms   

# Contributions and feedback
All very welcome, I am happy to accept pull requests with clean and tested code :):)
