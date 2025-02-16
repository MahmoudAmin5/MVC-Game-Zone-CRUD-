$.validator.addMethod('FileSize', function(value, elemnt, param){
    return this.Optional(elemnt) || elemnt.files[0].size <= param;
});