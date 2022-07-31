# Search Engine   [![.NET](https://github.com/Star-Academy/Summer1401-SE-Team02/actions/workflows/buildPipeline.yml/badge.svg)](https://github.com/Star-Academy/Summer1401-SE-Team02/actions/workflows/buildPipeline.yml)   [![codecov](https://codecov.io/gh/Star-Academy/Summer1401-SE-Team02/branch/TDD/graph/badge.svg?token=O6SO2O8I5D)](https://codecov.io/gh/Star-Academy/Summer1401-SE-Team02)

## Description
simple search engine simulation to understand how inverted-indexing works. you can search a word, and it will show you the documents containing that specific word.


## Features
* support for AND/OR operations
* finding files not including a word (exclusion) 

## Installation
#### simple search (single word)
after running the project you can simply type a word and the documents including that word will be returned.

ex: we want to fine all documents containing word "insert", so we simply type it:

```
insert
```

then you would be provided with such a result, showing name and number of documents including the word "insert":

```
number of search results: 10
[58876, 58823, 59489, 59072, 58139, 59478, 58773, 59639, 58946, 59546]
```

#### advanced search (and/or/exclusion)
imagine we are looking for documents, fitting with the requirments below:
* include both "test" and "less" words
* contains at least one of the words "hello" or "more" or "year"
* without the word "bad"

the good news is that we can still use this search engine considering these signs:

* add a ```+``` sign before the words you want to have at least one of them in your search
* for excluding a word, simply add a ```-``` sign before that
* words without ```+``` or ```-``` would be treated as the words you want them all to be contained in the search result.

So, we might use the below query for such a search:


```
test less -bad +hello +year +more
```

and the result would be:

```
number of search results: 3
[59245, 59435, 59126]
```
> Notice: order is not important!

#### End of program
simply type ```-1``` to finish the program.

## Interfaces
### Query
you can also create any kind of query that you want, simply by implementing Query interface.  imagine we want to add the feature of querying by sentences (complete human language support); this can be simply done without violating the Open/Closed principle of SOLID.

