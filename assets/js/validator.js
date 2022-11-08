// hàm đối tương validator
function Validator(options) {
    function getParent(element,selector) {
        while (element.parentElement){
            if(element.parentElement.matches(selector)){
                return element.parentElement;
            }
            element = element.parentElement;
        }
    }
    var selectorRules = {};
    // hàm thực hiện validate
    function validate(inpuElement, rule){
        var erorElement = getParent(inpuElement,options.formGroupSelector).querySelector(options.errorSelector);
        var errorMessage;
        // lấy ra các rules của selector
        var rules = selectorRules[rule.selector];
        //  lập qua từng rule và kiểm tra
        // nếu có lỗi thì kiểm tra
        for (var i = 0; i < rules.length; ++i) {
            switch (inpuElement.type){
                case 'radio':
                case 'checkbox':
                    errorMessage = rules[i](formElement.querySelector(rule.selector + ':checked')
                    );
                    break;
                default:
                    errorMessage = rules[i](inpuElement.value);
            }
            
            if (errorMessage) break;
        }
        
        if (errorMessage) {
            erorElement.innerText = errorMessage;
            getParent(inpuElement,options.formGroupSelector).classList.add('invalid');
        }
        else {
            erorElement.innerText = '';
            getParent(inpuElement,options.formGroupSelector).classList.remove('invalid');
        }
        return !errorMessage;
    }
    // lấy elment của form càn validate
    var formElement = document.querySelector(options.form);
    if(formElement){
        // khi submit form
        formElement.onsubmit = function (e) {
            e.preventDefault();
            var isFormValid = true;
            // lặp qua từng rules và validate
            options.rules.forEach(function(rule){
                var inpuElement = formElement.querySelector(rule.selector);
                var isValid = validate(inpuElement, rule);
                if(!isValid) {
                    isFormValid = false;
                }
            });
            
            if(isFormValid) {
                // trường hợp submit với js
                if(typeof options.onSubmit === 'function'){
                    var enableInputs = formElement.querySelectorAll('[name]');
                    var formValues = Array.from(enableInputs).reduce(function(values, input){
                        switch(input.type){
                            case 'radio':
                                values[input.name] = formElement.querySelector('input[name="' + input.name + '"]:checked').value;
                                break;
                            case 'checkbox':
                                if (!input.matches(':checked')){
                                    values[input.name] = '';
                                    return values;
                                }
                                if(!Array.isArray(values[input.name])){
                                    values[input.name] = [];
                                }
                                values[input.name].push(input.value);
                                break;
                            case 'file':
                                values[input.name] = input.files;
                                break;
                            default:
                                values[input.name] = input.value;
                        }
                        return values;
                    },{});
                    options.onSubmit(formValues);
                }
                // trường hợp submit với hành vi mặc đinh
                else {
                    formElement.submit();
                }
            }
        }
        //  lặp qua mỗi rule và sử lý (lắng nghe sự kiện)
        options.rules.forEach(function(rule){
            // lưu lại các rules của mỗi input
            if(Array.isArray(selectorRules[rule.selector])){
                selectorRules[rule.selector].push(rule.test);
            }
            else{
                selectorRules[rule.selector] = [rule.test];
            }
            
            var inpuElements = formElement.querySelectorAll(rule.selector);
            Array.from(inpuElements).forEach(function(inpuElement){
                //  xử lí khi người dùng blur khỏi input
                inpuElement.onblur = function(){
                    validate(inpuElement, rule);
                }
                // xử lí khi người dùng nhập
                inpuElement.oninput = function (){
                    var erorElement = getParent(inpuElement,options.formGroupSelector).querySelector(options.errorSelector);
                    erorElement.innerText = '';
                    getParent(inpuElement, options.formGroupSelector).classList.remove('invalid');
                }
            });
        });
    }
}
// định nghĩa rules
// nguyên tắc của rules:
// khi có lỗi tạo re mes lỗi
//  khi không có lỗi không trả gì cả (undefined)
Validator.isRequired = function(selector, message){
    return {
        selector: selector,
        test: function(value){
            return value ? undefined : message || 'Vui lòng nhập trường này'
        }
    };
}
Validator.isEmail = function(selector, message){
    return {
        selector: selector,
        test: function(value){
            var regex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
            return regex.test(value) ? undefined : message || 'Trường này phải là email';
        }
    };
}
Validator.minLength = function(selector, min, message){
    return {
        selector: selector,
        test: function(value){
            return value.length >= min ? undefined : message || `Vui lòng nhập tối thiểu ${min} ký tự`;
        }
    };
}
Validator.isConfirmed = function(selector , getConfirmValue, message){
    return {
        selector: selector,
        test: function(value){
            return value === getConfirmValue() ? undefined : message || 'Giá trị nhập vào không chính xác';
        }
    };
}
// ẩn hiện mật khẩu
var checkPass = true;
function showhide(){
    // if(checkPass){
    //     document.getElementById('password').setAttribute("type","text");
    //     checkPass = false;

    // }
    // else {
    //     document.getElementById('password').setAttribute("type","password");
    //     checkPass = true;
    // }
    
}
