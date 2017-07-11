#!/bin/bash

ssh -v root@github.com:kjsulls/ClearMeasure.git

echo '1. Updating sources'
cd c:/Projects/ClearMeasure
git checkout --force master
git pull


echo 'Done!'
