#!/bin/bash


for i in `seq 1000`
do
    nr=`shuf -i 100-1000 -n 1`
    line=
    for j in `seq ${nr}`
    do
        line=${line}\ $RANDOM
    done
    file=`printf test-%03d.in ${i}`
    echo writing ${nr} random numbers: ${file}
    echo ${line} > ${file}
done
