#!/bin/bash

for i in `seq 25`
do
    input=`printf test-%03d.in ${i}`
    sum=`printf sum-%03d.out ${i}`
    sort=`printf sort-%03d.out ${i}`
    /mnt/c/Program\ Files/dotnet/dotnet.exe ../build/SumApp.dll < ${input} > ${sum}
    /mnt/c/Program\ Files/dotnet/dotnet.exe ../build/SortApp.dll < ${input} > ${sort}
    echo done ${input}
done

