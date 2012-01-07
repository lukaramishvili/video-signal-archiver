import os
import shutil
import re
r = "V:\\"
yearList=os.listdir(r)
for y in yearList:
    if not(re.match("^\d+$",y)):
        continue
    monthList=os.listdir(r+"\\"+y)
    for m in monthList:
        dayList=os.listdir(r+"\\"+y+"\\"+m)
        for d in dayList:
            fileList = os.listdir(r+"\\"+y+"\\"+m+"\\"+d)
            for f in fileList:
                #shutil.move(r+"\\"+y+"\\"+m+"\\"+d+"\\"+f,r+"\\"+y+"\\"+m+"\\"+d+"\\"+y+"-"+m+"-"+d+"-"+f)
                #shutil.move(r+"\\"+y+"\\"+m+"\\"+d+"\\"+f,r+"\\"+y+"\\"+m+"\\"+d+"\\"+f.replace(y+"-"+m+"-"+d+"-",""))
                print (r+"\\"+y+"\\"+m+"\\"+d+"\\"+f.replace(y+"-"+m+"-"+d+"-",""))
            
