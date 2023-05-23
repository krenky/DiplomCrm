import { Console } from "console";
import { FieldProps } from "formik";
import React from "react";
import Select from "react-select";
import { OptionsType, ValueType } from "react-select/lib/types";

export interface Option {
    label: string;
    value: string;
}

interface CustomSelectProps extends FieldProps {
    options: OptionsType<Option>;
    isMulti?: boolean;
    className?: string;
    placeholder?: string;
    value:Option[]
}



export const SelecField = ({
    className,
    placeholder,
    field,
    form,
    options,
    isMulti = false,
    value
}: CustomSelectProps) => {
    const onChange = (option: ValueType<Option | Option[]>) => {
        form.setFieldValue(
            field.name,
            isMulti
                ? option as Option[]
                : (option as Option).value
        );
    };

    const getValue = () => {
        if (options) {
            return isMulti
                ? options.filter(option => {
                    field.value?field.value:field.value = [];
                    const result = field.value.find((values:Option) => {
                        console.log(values);
                        return values.value === option.value});
                    if(result)
                        return result != null && result != undefined
                })
                : options.find(option => option.value === field.value);
        } else {
            return isMulti ? [] : ("" as any);
        }
    };
    
    return (
        <Select
            className={className}
            name={field.name}
            value={getValue()}
            //value={value}
            onChange={onChange}
            placeholder={placeholder}
            options={options}
            isMulti={isMulti}
        />
    );
};

export default SelecField;
