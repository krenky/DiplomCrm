import { Box, Button, Checkbox, CircularProgress, FormControlLabel, Modal, TextField, useTheme } from "@mui/material";
import { Field, Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import Header from "../../components/Header";
import { InventoryItem, RegisterModel, RepairOrder, RepairWork, SalesStages } from "../../Type"
import React, { useEffect, useState } from "react";
import { tokens } from "../../theme";
import dataProvider, { RequestOptions, DataProviderResponse, DataProvider } from '../../providers/dataProvider';
import CurrencyTextField from '@unicef/material-ui-currency-textfield'
import { Option, SelecField } from "../../components/SelectField";
import { optionCSS } from "react-select/lib/components/Option";

const phoneRegExp =
    /^((\+[1-9]{1,4}[ -]?)|(\([0-9]{2,3}\)[ -]?)|([0-9]{2,4})[ -]?)*?[0-9]{3,4}[ -]?[0-9]{3,4}$/;



const defaultStages: SalesStages = {
    id: '',
    name: '',
    isFirstDefault: false,
    isLastDefault: false,
    isCancelDefault: false,
    orders: []
}

const RepairOrderFormik = (props: {
    repairOrder: RepairOrder | undefined,
    allParts: InventoryItem[] | undefined,
    allWorks: RepairWork[] | undefined
}) => {



    const initialValues = props.repairOrder ? {
        repairOrder: props.repairOrder,
        allRepairWorks: props.allWorks,
        allPartsUsed: props.allParts,
    } :
        {
            salesStages: defaultStages,
            salesStagesId: "",
            description: "",
            startedAt: new Date(Date.now()),
            endedAt: new Date(Date.now()),
            created: new Date(Date.now()),
            updated: new Date(Date.now()),
            customerName: "",
            deviceName: "",
            allRepairWorks: [] as RepairWork[],
            repairWorks: [] as Option[],
            price: 0,
            loyaltyDiscount: false,
            partsUsed: [] as Option[],
            allPartsUsed: [] as InventoryItem[]
        }
    const userSchema = yup.object().shape({
        repairOrder: yup.object().shape({
            id: yup.string().required(),
            customerId: yup.string().required(),
            deviceId: yup.string().required(),
            salesStagesId: yup.string().required(),
            description: yup.string().required(),
            created: yup.date().required(),
            updated: yup.date().required(),
            applicationUserId: yup.string().required(),
            price: yup.string().required(),
            loyaltyDiscount: yup.boolean().required(),
        })
    });
    const isNonMobile = useMediaQuery("(min-width:600px)");
    const handleForSumbit = (values: any) => {
        console.log(values)
    }


    const theme = useTheme();
    const colors = tokens(theme.palette.mode);

    const style = {
        bgcolor: colors.primary[600],
    };


    return <Box m={"20px"}>
        <Header title="Редактирование заявки" subtitle="Редактирование заявки" />
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
                            label="ФИО Менеджера"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.repairOrder?.applicationUser?.userName}
                            name="userName"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Этап продажи"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.repairOrder?.salesStages.name}
                            name="salesStages"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="datetime"
                            label="Дата создания"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.repairOrder?.created}
                            name="created"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="datetime"
                            label="Дата обновления"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.repairOrder?.updated}
                            name="updated"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Описание поломки"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.repairOrder?.description}
                            name="description"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Модель"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.repairOrder?.device?.name}
                            name="deviceName"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <TextField
                            fullWidth
                            variant="filled"
                            type="text"
                            label="Производитель"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            value={values.repairOrder?.device?.manufacturer}
                            name="manufacturer"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <CurrencyTextField
                            fullWidth
                            variant="filled"
                            label="Сумма"
                            onBlur={handleBlur}
                            onChange={handleChange}
                            currencySymbol="₽"
                            outputFormat="string"
                            value={values.repairOrder?.price}
                            name="price"
                            error={!!touched.repairOrder && !!errors.repairOrder}
                            //helperText={touched.repairOrder && errors.repairOrder}
                            sx={{ gridColumn: "span 2" }}
                        />
                        <Field
                            fullWidth
                            variant="filled"
                            className="partsUsed"
                            name="partsUsed"
                            label="Список запчастей"
                            options={convertInventoryItem(initialValues.allPartsUsed)}
                            component={SelecField}
                            placeholder="Выберите запчасти..."
                            isMulti={true}
                            value={convertInventoryItem(initialValues.repairOrder?.partsUsed)}//field
                            sx={{ gridColumn: "span 2" }}
                        />
                        <Field
                            fullWidth
                            variant="filled"
                            className="repairWorks"
                            name="repairWorks"
                            label="Ремонрные работы"
                            options={convertRepairWork(initialValues.allRepairWorks)}
                            component={SelecField}
                            placeholder="Выберите работы..."
                            isMulti={true}
                            value={convertRepairWork(initialValues.repairOrder?.repairWorks)}//field
                            sx={{ gridColumn: "span 2" }}
                        />
                        <FormControlLabel
                                control={<Checkbox checked={values.repairOrder?.loyaltyDiscount} value={true} />}
                                label="Скидка постоянного клиента"
                                name="repairOrder.loyaltyDiscount"
                                onChange={handleChange}
                            />
                    </Box>
                    <Box display="flex" justifyContent="end" mt="20px">
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            let user: RepairOrder | undefined = values.repairOrder;
                            if (user) {
                                user.loyaltyDiscount = values.repairOrder?values.repairOrder.loyaltyDiscount:false;
                                user.partsUsed = values.allPartsUsed?.filter(item => values.partsUsed?.some(opt => opt.value == item.id))//values.partsUsed ? convertPartsOption(values.partsUsed, values.allPartsUsed) : user.partsUsed;
                                user.repairWorks = values.allRepairWorks?.filter(item => values.repairWorks?.some(opt => opt.value == item.id.toString()))//values.repairWorks ? convertWorksOption(values.repairWorks, values.allRepairWorks) : user.repairWorks;
                                SaveRepairOrder(user, user.id || '-1')
                                console.log(user);
                            }
                        }}>
                            Сохранение
                        </Button>
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            if (values.repairOrder)
                                if (values.repairOrder.id)
                                    SetNextSalesStages(values.repairOrder, values.repairOrder.id)
                        }
                        }>
                            Следующий этап
                        </Button>
                        <Button type="submit" color="secondary" variant="contained" onClick={() => {
                            if (values.repairOrder)
                                if (values.repairOrder.id)
                                    SetCancelSalesStages(values.repairOrder, values.repairOrder.id)
                        }
                        }>
                            Отмена заявки
                        </Button>
                    </Box>
                </form>
            )}
        </Formik>
    </Box>
}

function convertPartsOption(option: Option[] | undefined, all: InventoryItem[] | undefined): InventoryItem[] {

    if (all)
        if (option) {
            return all.filter((item) => option.some((opt) => opt.value === item.id)) || [] as InventoryItem[];
        }
    return [] as InventoryItem[];
}
function convertWorksOption(option: Option[] | undefined, all: RepairWork[] | undefined): RepairWork[] {

    if (all)
        if (option) {
            return all.filter((item) => option.some((opt) => opt.value === item.id.toString())) || [] as RepairWork[];
        }
    return [] as RepairWork[];
}
// function findItem(option:Option[], item:InventoryItem):InventoryItem{
//     if(option.findIndex(option => option.value === item.id) != -1 )
//     return item
// }


//const Moda
function convertInventoryItem(item: InventoryItem[] | undefined): Option[] {
    return item ? item.map((item) => {
        const values: Option = {
            label: item.name.toString(),
            value: item.id.toString()
        }
        return values;
    }
    ) : [] as Option[]
}
function convertRepairWork(item: RepairWork[] | undefined): Option[] {
    return item ? item.map((item) => {
        const values: Option = {
            label: item.name.toString(),
            value: item.id.toString()
        }
        return values;
    }
    ) : [] as Option[]
}

export const RepairOrderModal = (props: { open: boolean, handleClose: () => void, order: RepairOrder | undefined }) => {
    const [open, setOpen] = React.useState(false);
    //const handleOpen = () => setOpen(true);
    //const handleClose = () => setOpen(false);
    const [loading, setLoading] = useState<boolean>(true);
    const [parts, setParts] = useState<InventoryItem[]>();
    const [works, setWorks] = useState<RepairWork[]>();
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const style = {
        position: 'absolute' as 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: '100%',
        bgcolor: colors.primary[200],
        border: '2px solid #000',
        boxShadow: 24,
        pt: 2,
        px: 4,
        pb: 3,
    };
    useEffect(() => {
        dataProvider.getList<InventoryItem>('InventoryItems')
            .then((result) => {
                if (result.data) {
                    setParts(result.data)

                }

            })
        dataProvider.getList<RepairWork>('RepairWorks')
            .then((result) => {
                if (result.data) {
                    setWorks(result.data)
                    setLoading(false);
                }

            })
    }, [])

    if (loading) {
        return <CircularProgress />;
    }



    return (
        <Modal
            open={props.open}
            onClose={props.handleClose}
            sx={{
                width: '60%', height: '60%', position: 'center'/*, bgcolor: colors.blueAccent[100]*/
            }}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
        >
            <Box borderColor={colors.greenAccent} sx={{ ...style }} /*</Modal>bgcolor={colors.grey[400]}*/>
                <RepairOrderFormik repairOrder={props.order} allParts={parts} allWorks={works} />
            </Box>
        </Modal>)
}

function CreatUser(user: RegisterModel) {
    dataProvider.create<RegisterModel>('Authenticate/register', user)
        .then(value => { return value.data })
        .catch(reason => { return reason });
}
function SaveRepairOrder(order: RepairOrder, id: string) {
    dataProvider.update<RepairOrder>('repairorders', id, order)
}

function SetNextSalesStages(order: RepairOrder, id: string) {
    dataProvider.update<RepairOrder>('repairorders/nextstages', id, order)
}

function SetCancelSalesStages(order: RepairOrder, id: string) {
    dataProvider.update<RepairOrder>('repairorders/cancelstages', id, order)
}


export default RepairOrderModal;