/**
 * 'date-carousel'
 * 
 * Author: Jack Grantham
 * Date: 04.07.2022
 * 
 */
class DateCarousel extends HTMLElement
{
    constructor()
    {
        // Always call super first in constructor so that correct prototype chain is established
        super();

        // Element functionality written here
    }

    connectedCallback()
    {
        const now = new Date();
        this.today = (now.getMonth() + 1) + '/' + now.getDate() + '/' + now.getFullYear();
        this.weekInView = this._getFirstDayOfWeek(this.today);

        this._calculateDays();

        this.innerHTML = this.render();
    }

    attributeChangedCallback()
    {
        // invoked when one of the custom element's attributes is added, removed, or changed
    }

    _calculateDays()
    {
        let days = [];
        let currentDayCount = 1;
        let currentDay = this.weekInView;

        while (currentDayCount <= 7)
        {
            days.push
                ({
                    dayOfWeek: currentDay.getDay(),
                    dayOfMonth: currentDay.getDate(),
                    day: currentDay.getDay(),
                });


            currentDayCount++;
        }

        this._days = days
    }

    /**
     * Returns the first day of the current week (Sun) given todays date.
     * 
     * @param {any} d 
     */
    _getFirstDayOfWeek(d)
    {
        const date = new Date(d);
        const day = date.getDay();

        // Day of the Month - Day of the Week
        const diff = date.getDate() - day; //  + (day === 0 ? -6 : 1)

        return new Date(date.setDate(diff));
    }

    render()
    {
        return `
            <style>
                
            </style>
            <table>
                <tr>
                    <td>
                    </td>
                    ${this._days.map(day => '<td>${day.dayOfMonth}</td>')}
                    <td>
                    </td>
                </tr>
            </table>
        `;
    }
}

// Create a Custom Element for Date Carousel class
window.customElements.define('date-carousel', DateCarousel);