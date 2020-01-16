import moment from 'moment';

export const getUTCNow = () => moment().utc().format();
export const toLocalTime = (dateTime) =>moment(dateTime).format('YYYY年MM月DD日 HH:mm');