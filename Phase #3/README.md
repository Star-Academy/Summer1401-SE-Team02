# Top N Students Finder

## Description
Simple C# project to output the N best students regarding their grades average.

## Features
* Read data from different sources (Web and File already implemented as demonstration)
* Designed based on SOLID
* Support for different serializing methods (Json icluded)

## Installation
#### simple search (single word)
simply run the program and output will be shown.
ex: for the files included in resources folder, the output would be as below: 

```
4: Hossein Behbodi -> 17.24
1: Mahdi Malverdi -> 15.29
3: Mohammad Hossein Mostmand -> 15.26
```

## Interfaces
### IDeserializer
you can also create any kind of deserilazier that you want, simply by implementing IDeserializer interface. imagine we want to add the feature of deserializing CSV or XML strings; this can be simply done without violating the Open/Closed principle of SOLID.

### IDataProvider
students and grades data may be provided by different sources. To change the current one, you can implement this interface for any other source that you want. (for a demonstration we have already implemented the WebDataProvider)