import { Box, Button, TextField, useMediaQuery } from "@mui/material";
import * as yup from "yup";
import Header from "../../components/Header";
import { Formik } from "formik";
import { AdvertisingСompany } from "../../Type";
import dataProvider from "../../providers/dataProvider";

const initialValues = {
    name: "",
    discount: 0,
    description: "",
    code: ""
}
const userSchema = yup.object().shape({
    name: yup.string().required("required"),
    discount: yup.number().required("required"),
    description: yup.string().required("required"),
    code: yup.string().required("required"),
});

const AdvertisingСompanyAdd = () => {
    const isNonMobile = useMediaQuery("(min-width:600px)");
    const handleForSumbit = (values: any) => {
        console.log(values)
    }
    return <Box m={"20px"}>
        <Header title="Регистрация сотрудника" subtitle="Регистрация нового сотрудника" />
        <Formik
            onSubmit={handleForSumbit}
            initialValues={initialValues}
            validationSchema={userSchema}>
            {({
                values,
                errors,
                touched,
                handleBlur,
                handleChange,
                handleSubmit,
            }) => (
                <form onSubmit={handleSubmit}>
                    <Box
                        display="grid"
                        gap="30px"
                        gridTemplateColumns="repeat(4, minmax(0, 1fr))"
                        sx={{
                            "& > div": { gridColumn: isNonMobile ? undefined : "span 4" },
                        }}
                    >
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Наименование компании"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.name}
                            name="name"
                            error={!!touched.name && !!errors.name}
                            //helperText={touched.name && errors.name}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="number"
                            label="Скидка в %"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.discount}
                            name="discount"
                            error={!!touched.discount && !!errors.discount}
                            helperText={touched.discount && errors.discount}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Описание"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.description}
                            name="description"
                            error={!!touched.description && !!errors.description}
                            helperText={touched.description && errors.description}
                            sx={{ gridColumn: "span 4" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Промо-код"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.code}
                            name="code"
                            error={!!touched.code && !!errors.code}
                            helperText={touched.code && errors.code}
                            sx={{ gridColumn: "span 4" }}
                        />
                    </Box>
                    <Box display="flex" justifyContent="end" mt="20px">
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            const user: AdvertisingСompany = {
                                name: values.name,
                                discount: values.discount,
                                description: values.description,
                                code: values.code
                            }
                            CreateCompany(user);
                        }}>
                            Создание
                        </Button>
                    </Box>
                </form>
            )}
        </Formik>
    </Box>
}

export default AdvertisingСompanyAdd;

function CreateCompany(company:AdvertisingСompany){
    dataProvider.create<AdvertisingСompany>('AdvertisingСompany', company);
}