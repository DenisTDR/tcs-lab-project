#!/bin/bash


for i in `seq 25`
do
    nr=`shuf -i 500-10000 -n 1`
    line=
    for j in `seq ${nr}`
    do
        line=${line}\ $RANDOM
    done
    file=`printf test%03d.in ${i}`
    echo writing ${nr} random numbers: ${file}
    echo ${line} > ${file}
done
