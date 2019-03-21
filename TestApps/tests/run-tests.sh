#!/bin/bash

for i in `seq 1000`
do
    input=`printf test-%03d.in ${i}`
    sum=`printf sum-%03d.out ${i}`
    sort=`printf sort-%03d.out ${i}`
    C:/Program\ Files/dotnet/dotnet.exe ../build/SumApp.dll < ${input} > ${sum}
    C:/Program\ Files/dotnet/dotnet.exe ../build/SortApp.dll < ${input} > ${sort}
    echo done ${input}
done

