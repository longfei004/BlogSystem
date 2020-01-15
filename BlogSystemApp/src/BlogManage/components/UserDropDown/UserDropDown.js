import React from 'react';
import { Link } from 'react-router-dom';
import { Menu, Dropdown, Icon } from 'antd';
import './UserDropDown.less';

const UserDropDown = () => {

    const menu = (
        <Menu>
            <Menu.Item key="1">
                <div className='user-item'>
                    <Link to='/blogs/edit'>我的博客</Link>
                </div>
            </Menu.Item>
        </Menu>
    );

    return (
        <div className='user-drop-down'>
            <Dropdown overlay={menu}>
                <Icon type="caret-down" />
            </Dropdown>
        </div>
    )
}

export default UserDropDown;
