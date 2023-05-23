import { options } from "@fullcalendar/core/preact.js";
import { FieldProps } from "formik";
import React from "react";
import Select from "react-select";
import { OptionsType, ValueType } from "react-select/lib/types";
import dataProvider from "../providers/dataProvider";
import { RepairWork } from "../Type";

export interface Option {
    label: string;
    value: string;
}

interface CustomSelectProps extends FieldProps {
    options: OptionsType<Option>;
    isMulti?: boolean;
    className?: string;
    placeholder?: string;
    idOrder: string
}



export const SelecFieldRepairWork = ({
    className,
    placeholder,
    field,
    form,
    options,
    isMulti = false,
    idOrder
}: CustomSelectProps) => {
    const onChange = (option: ValueType<Option | Option[]>) => {
        form.setFieldValue(
            field.name,
            isMulti
                ? (option as Option[]).map((item: Option) => item.value)
                : (option as Option).value
        );
    };

    const getValue = () => {
        if (options) {
            return isMulti
                ?
                dataProvider.getListWithId<RepairWork>('RepairOrders/RepairWork', idOrder)
                    .then((result) => {
                        if (result.data)
                            return result.data.map((item) => {
                                console.log(item.name.toString())
                                console.log(item.id.toString())
                                const values: Option = {
                                    label: item.name.toString(),
                                    value: item.id.toString()
                                }
                                return values;
                            }
                            )
                    })
                    .catch((error) => console.error(error))
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
        onChange={onChange}
        placeholder={placeholder}
        options={options}
        isMulti={isMulti}
    />
);
};

export default SelecFieldRepairWork;
