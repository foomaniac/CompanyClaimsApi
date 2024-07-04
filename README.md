# CompanyClaimsApi

## Introduction

This API exposes endpoints that provide informstion on a company and it's attributes, as well as claims links to that company.

For reference the API follows a vertical slice approach to it's solution structure, the reason for this being it has minimal responsibilities so I felt it suited this structure for this first interation. Would expect to have a discussion about this prior to any new api build.

Core structure is around 'feature' folders, organised in this instance by claims and companies.

Claims can be found in:

**Features/Claims**

Companies can be found in:

**Features/Companies**

The data layer sits within the 'data' folder at the root of the solution.

## Getting Started

The solution does not have a persistance layer fully implemented, therefore sample data is created via an EF dbcontext when the solution starts up, using an InMemory database. Therefore you can simply open the solution and hit debug to run it locally.

Sample company id's for reference are 1,2 & 3. You can then view claims, get claim information and also update a claim as required.



