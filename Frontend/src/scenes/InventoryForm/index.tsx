import { Box, Button, Modal, TextField, useTheme } from "@mui/material";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import Header from "../../components/Header";
import { InventoryItem } from "../../Type"
import React from "react";
import { tokens } from "../../theme";
import dataProvider, { RequestOptions, DataProviderResponse, DataProvider } from '../../providers/dataProvider'

const phoneRegExp =
    /^((\+[1-9]{1,4}[ -]?)|(\([0-9]{2,3}\)[ -]?)|([0-9]{2,4})[ -]?)*?[0-9]{3,4}[ -]?[0-9]{3,4}$/;

const initialValues = {
    Inventoryname: "",
    description: "",
    price: 0,
    picture: "",
    quantityInStock: 0
}
const InventoryItemSchema = yup.object().shape({
    Inventoryname: yup.string().required("Обязательный к заполнению!"),
    description: yup.string().required("Обязательный к заполнению!"),
    price: yup.string().required("Обязательный к заполнению!"),
    picture: yup.string().required("Обязательный к заполнению!"),
    quantityInStock: yup.string().required("Обязательный к заполнению!")
});

const Form = () => {
    const isNonMobile = useMediaQuery("(min-width:600px)");
    const handleForSumbit = (values: any) => {
        console.log(values)
    }

    return <Box m={"20px"}>
        <Header title="Добавление материалов" subtitle="Добавление материалов" />
        <Formik
            onSubmit={handleForSumbit}
            initialValues={initialValues}
            validationSchema={InventoryItemSchema}>
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
                            label="Название"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.Inventoryname}
                            name="Inventoryname"
                            error={!!touched.Inventoryname && !!errors.Inventoryname}
                            helperText={touched.Inventoryname && errors.Inventoryname}
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
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="number"
                            label="Стоимость"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.price}
                            name="price"
                            error={!!touched.price && !!errors.price}
                            helperText={touched.price && errors.price}
                            sx={{ gridColumn: "span 4" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Фото"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.picture}
                            name="picture"
                            error={!!touched.picture && !!errors.picture}
                            helperText={touched.picture && errors.picture}
                            sx={{ gridColumn: "span 4" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="number"
                            label="Остаток"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.quantityInStock}
                            name="quantityInStock"
                            error={!!touched.quantityInStock && !!errors.quantityInStock}
                            helperText={touched.quantityInStock && errors.quantityInStock}
                            sx={{ gridColumn: "span 4" }}
                        />
                    </Box>
                    <Box display="flex" justifyContent="end" mt="20px">
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            const InventoryItem: InventoryItem = {
                                id:'0',
                                name: values.Inventoryname,
                                description: values.description,
                                price: values.price,
                                picture: values.picture,
                                quantityInStock: values.quantityInStock
                            }  
                            CreatInventoryItem(InventoryItem);
                        }}>
                            Create New InventoryItem
                        </Button>
                    </Box>
                </form>
            )}
        </Formik>
    </Box>
    
}

//const Moda

export const ModalForm = (props: { open: boolean, handleClose: () => void }) => {
    const [open, setOpen] = React.useState(false);
    //const handleOpen = () => setOpen(true);
    //const handleClose = () => setOpen(false);
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    return (
        <Modal
            open={props.open}
            onClose={props.handleClose}
            sx={{
                width: '100%', height: '100%', bgcolor: 'white'
            }}
        // aria-labelledby="modal-modal-title"
        // aria-describedby="modal-modal-description"
        >
            <Box>
                <Form />
            </Box>
        </Modal>)
}

function CreatInventoryItem(InventoryItem: InventoryItem) {
    dataProvider.create<InventoryItem>('InventoryItems', InventoryItem)
        .then(value => { return value.data })
        .catch(reason => { return reason });
}


export default Form;