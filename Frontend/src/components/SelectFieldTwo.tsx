import React from 'react';
import { useField } from 'formik';
import Select from 'react-select';
import { ValueType, OptionType } from 'react-select/lib/types';

interface SelectFieldProps {
    name: string;
    options: { value: string; label: string }[];
    label: string;
}

const SelectField: React.FC<SelectFieldProps> = ({ name, options, label }) => {
    const [field, meta, helpers] = useField(name);

    const handleChange = (selectedOption: ValueType<OptionType>) => {
        helpers.setValue(selectedOption ? (selectedOption as { value: string }).value : null);
    };

    const handleBlur = () => {
        helpers.setTouched(true);
    };

    return (
        <div>
            <label htmlFor={name}>{label}</label>
            <Select
                id={name}
                name={name}
                options={options}
                value={options.find((option) => option.value === field.value)}
                onChange={handleChange}
                onBlur={handleBlur}
            />
            {meta.touched && meta.error && <div>{meta.error}</div>}
        </div>
    );
};
