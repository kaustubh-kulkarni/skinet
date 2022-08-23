# Core folder #

## This folder consist of domain entities that we have ##

**Specification Pattern and generics**
We are using some generics and specification pattern to reduce the amount of code.
We replace all the entity types the we are passing to the methods by a placeholder T.
This T is going to derive from the base entity and we can then replace T by which type we want to work on.